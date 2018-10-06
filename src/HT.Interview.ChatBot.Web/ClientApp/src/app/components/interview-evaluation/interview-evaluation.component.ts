import { Component, OnInit, Input} from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../../models/user';
import { Constants } from '../../models/constants';
import { GridAddButtonComponent } from '../custom/grid-add-button/grid-add-button.component';
import { DownloadFileComponent } from '../custom/download-file/download-file.component';
import { RoleEnum } from '../../models/enums';
import { OperationMode } from '../../models/enums';
import { GridOptions } from "ag-grid-community";
import { PaginationInstance } from 'ngx-pagination';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-interview-evaluation',
  templateUrl: './interview-evaluation.component.html',
  styleUrls: ['./interview-evaluation.component.css']
})
export class InterviewEvaluationComponent implements OnInit {


  @Input('data') meals: string[] = [];

  private viewGridOptions: GridOptions;
  private evaluateGridOptions: GridOptions;
  private viewGridColumns;
  private evaluateGridColumns;
  private viewGridData: any;
  private evaluateGridData: any;

  private webAPIGetCandidatesUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getManyByRoleId + '?roleId=' + RoleEnum.Candidate;
  private webAPIGetInterviewDetailUrl = environment.application.webAPIUrl + environment.controller.interviewController + environment.action.getInterviewDetailByUserId + '?userId=';
  private webAPIUpdateUserInterviewResultUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.updateUserInterviewResult;
  private webAPIDownloadResumeUrl = environment.application.webAPIUrl + environment.controller.downloadController + environment.action.getWithParameters + 'filePath=';

  //private paginationPageSize = environment.application.pageSize;
  private paginationPageSize = 2;
  private user = new User();
  private constants = new Constants();
  private loggedInUser = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));
  private operationMode: OperationMode = OperationMode.View;
  private endResultSelect: any;
                                
  private maxSize: number = 10;
  private directionLinks: boolean = true;
  private autoHide: boolean = false;
  private responsive: boolean = false;

  private config: PaginationInstance = {
    id: 'advanced',
    itemsPerPage: environment.application.pageSize,
    currentPage: 1
  };

  private labels: any = {
    previousLabel: 'Previous',
    nextLabel: 'Next',
    screenReaderPaginationLabel: 'Pagination',
    screenReaderPageLabel: 'page',
    screenReaderCurrentLabel: `You're on page`
  };

  ngOnInit() {
    this.user = new User();
    this.endResultSelect = [
      { id: "Selected", name: "Selected" },
      { id: "Not Selected", name: "Not Selected" },
      { id: "On Hold", name: "On Hold" },
      { id: "Required further evaluation", name: "Required Further Evaluation" }
    ];;
  }

  constructor(private http: HttpClient) {

    var timeCellRenderer = function (): any {
    };

    this.viewGridOptions = <GridOptions>{
      context: {
        componentParent: this
      }
    };

    this.evaluateGridOptions = <GridOptions>{
      components: {
        'TimeCellRenderer': timeCellRenderer
      }
    };

    this.viewGridColumns = [
      {
        headerName: "Interview Date", field: "interviewDate", suppressSizeToFit: false, filter: 'agDateColumnFilter',
        cellRenderer: (data) => { return data.value ? (new Date(data.value)).toLocaleDateString() : ''; }
      },
      { headerName: "Profile Name", field: "profileName", suppressSizeToFit: true, filter: 'agTextColumnFilter' },
      { headerName: "Candidate Name", field: "displayName", suppressSizeToFit: false, filter: 'agTextColumnFilter' },
      {
        headerName: "Resume",
        suppressSizeToFit: false,
        cellRendererFramework: DownloadFileComponent
      },
      { headerName: "Remark", filter: 'agTextColumnFilter', field: "remark" },
      { headerName: "End Result", filter: 'agTextColumnFilter', field: "endResult" },
      {
        headerName: "Evaluate",
        cellRendererFramework: GridAddButtonComponent
      }
    ];

    this.evaluateGridColumns = [
      {
        headerName: "SN", field: "rowNumber", suppressSizeToFit: true, filter: 'agTextColumnFilter',
        cellRenderer: params => { return `<div style="text-align:center;"> ${params.value}</div>`; },
        width: 60, maxWidth: 60
      },
      { headerName: "Bot Response/Question", field: "botResponse", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 600 },
      { headerName: "Candidate Reponse", field: "userResponse", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 400 },
      {
        headerName: "Expected Answer", field: "expectedAnswer", suppressSizeToFit: true, filter: 'agTextColumnFilter',
        width: 160, maxWidth: 160,
      },
      {
        headerName: "Allocated Time", field: "allocatedTime", suppressSizeToFit: true, filter: 'agTextColumnFilter',
        valueFormatter: this.timeFormatter, cellClass: 'grid-time-cell', width: 140, maxWidth: 140,
      },
      {
        headerName: "Time Taken", field: "timeTaken", suppressSizeToFit: true, filter: 'agTextColumnFilter',
        valueFormatter: this.timeFormatter, cellClass: 'grid-time-cell', width: 120, maxWidth: 120
      }
    ];
  }

  onFirstDataRendered(params) {
    params.api.sizeColumnsToFit();
  }

  onViewGridReady() {
    this.http.get(this.webAPIGetCandidatesUrl)
      .subscribe(data => {
        this.viewGridData = data;
      });
  }

  onEvaluateGridReady() {
    this.http.get(this.webAPIGetInterviewDetailUrl + this.user.id)
      .subscribe(data => {
        this.evaluateGridData = data;
      });
  }

  gridAddButtonClick(data) {
    this.user.id = data.id;
    if (data.endResult == null) {
      this.user.endResult = "On Hold";
    }
    else {
      this.user.endResult = data.endResult;
    }
    this.user.remark = data.remark;
    this.operationMode = OperationMode.Edit;                  
  }

  downloadFile(data) {
    if (data.resumeFilePath != null) {
      const a = document.createElement('a');
      a.style.display = 'none';
      a.href = this.webAPIDownloadResumeUrl + data.resumeFilePath;
      document.body.appendChild(a);
      a.click();
      setTimeout(() => {
        document.body.removeChild(a);
      }, 100);
    }
  }

  onSave() {
    this.user.modifiedBy = this.loggedInUser.email;
    var body = JSON.stringify(this.user);

    var httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    this.http.put(this.webAPIUpdateUserInterviewResultUrl, body, httpOptions).subscribe(data => {
      this.operationMode = OperationMode.View;
    });
  }

  onCancel() {
    this.operationMode = OperationMode.View;
  }

  // time formatter
  timeFormatter(params): string {
    if (params.value === 0 || params.value === "" || params.value === undefined || params.value === null) {
      return '';
    }
    else {
      return String(params.value) + ' sec';
    }
  }
         
  onPageChange(number: number) {
    this.config.currentPage = number;
  }     
}    
