import { Component, OnInit, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { GridOptions } from "ag-grid-community";
import { PaginationInstance } from 'ngx-pagination';
import * as moment from 'moment';
import { GridAddButtonComponent } from '../custom/grid-add-button/grid-add-button.component';
import { DownloadFileComponent } from '../custom/download-file/download-file.component';
import { User } from '../../models/user';
import { Constants } from '../../models/constants';
import { RoleEnum } from '../../models/enums';
import { OperationMode } from '../../models/enums';
import { environment } from '../../../environments/environment';
import { FILE } from 'dns';

@Component({
  selector: 'app-interview-evaluation',
  templateUrl: './interview-evaluation.component.html',
  styleUrls: ['./interview-evaluation.component.css']
})
export class InterviewEvaluationComponent implements OnInit {


  @Input('data') meals: string[] = [];

  private evaluateGridApi;
  private evaluateGridOptions: GridOptions;
  private evaluateGridColumns;
  private evaluateGridData: any;

  private evaluateResultGridApi;
  private evaluateResultGridOptions: GridOptions;
  private evaluateResultGridData: any;
  private evaluateResultGridColumns;

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
  private domLayout = "autoHeight";

  private evaluateGridPagingConfig: PaginationInstance = {
    id: 'advanced',
    itemsPerPage: environment.application.pageSize,
    currentPage: 1
  };

  private evaluateResultGridPagingConfig: PaginationInstance = {
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
      { id: "Require further evaluation", name: "Require Further Evaluation" }
    ];;
  }

  constructor(private http: HttpClient) {

    var timeCellRenderer = function (): any {
    };

    this.evaluateGridOptions = <GridOptions>{
      context: {
        componentParent: this
      }
    };

    this.evaluateResultGridOptions = <GridOptions>{
      components: {
        'TimeCellRenderer': timeCellRenderer
      }
    };

    this.evaluateGridColumns = [
      {
        headerName: "Interview Date", field: "interviewDate", filter: 'agDateColumnFilter',
        cellRenderer: (data) => { return data.value ? (moment(data.value).format('DD/MM/YYYY')) : ''; },
        cellClass: "ag-grid-cell-text-center", width: 130
      },
      { headerName: "Profile Name", field: "profileName", filter: 'agTextColumnFilter' },
      { headerName: "Candidate Name", field: "displayName", filter: 'agTextColumnFilter' },
      { headerName: "Resume", cellRendererFramework: DownloadFileComponent, width: 100 },
      { headerName: "Recording", cellRendererFramework: DownloadFileComponent, width: 100 },
      { headerName: "Remark", filter: 'agTextColumnFilter', field: "remark", cellClass: "ag-grid-cell-wrap-text", autoHeight: true, width: 150 },
      {
        headerName: "End Result", filter: 'agTextColumnFilter', field: "endResult",
        cellStyle: function (params) {
          if (params.value == 'Selected') {
            return { color: 'darkgreen', fontWeight: 'bold' };
          } else if (params.value == 'Not Selected') {
            return { color: 'red', fontWeight: 'bold'  };
          } else if (params.value == 'On Hold') {
            return { color: 'darkblue', fontWeight: 'bold'  };
          } else if (params.value == 'Require further evaluation') {
            return { color: 'darkorange', fontWeight: 'bold'  };
          }
          return null;
        }
      },
      { headerName: "Evaluate", cellRendererFramework: GridAddButtonComponent, width: 100 }
    ];

    this.evaluateResultGridColumns = [
      {
        headerName: "", field: "rowNumber", filter: 'agTextColumnFilter', autoHeight: false, width: 40,
        cellRenderer: params => { return `<div style="text-align:center;"> ${params.value}</div>`; },
      },
      {
        headerName: "Bot Response/Question", field: "botResponse", filter: 'agTextColumnFilter',
        cellClass: "ag-grid-cell-wrap-text", autoHeight: true, width: 400
      },
      {
        headerName: "Candidate Reponse", field: "userResponse", filter: 'agTextColumnFilter',
        cellClass: "ag-grid-cell-wrap-text", autoHeight: true, width: 300
      },
      {
        headerName: "Expected Answer", field: "expectedAnswer", filter: 'agTextColumnFilter',
        cellClass: "ag-grid-cell-wrap-text", autoHeight: true
      },
      {
        headerName: "Allocated Time", field: "allocatedTime", filter: 'agTextColumnFilter', valueFormatter: this.timeFormatter,
        cellClass: 'ag-grid-cell-text-center', autoHeight: false, width: 120
      },
      {
        headerName: "Time Taken", field: "timeTaken", filter: 'agTextColumnFilter', valueFormatter: this.timeFormatter,
        cellClass: 'ag-grid-cell-text-center', autoHeight: false, width: 120
      }
    ];

  }

  onEvaluateGridReady(params) {
    this.evaluateGridApi = params.api;
    this.http.get(this.webAPIGetCandidatesUrl)
      .subscribe(data => {
        this.evaluateGridData = data;
      });
    setTimeout(function () {
      params.api.resetRowHeights();
    }, 500);
  }

  onEvaluateGridColumnResized(event) {
    if (event.finished) {
      this.evaluateGridApi.resetRowHeights();
    }
  }

  onEvaluateGridPageChange(number: number) {
    this.evaluateGridPagingConfig.currentPage = number;
  }

  onEvaluateResultGridReady(params) {
    this.evaluateResultGridApi = params.api;
    this.http.get(this.webAPIGetInterviewDetailUrl + this.user.id)
      .subscribe(data => {
        this.evaluateResultGridData = data;
      });
    setTimeout(function () {
      params.api.resetRowHeights();
    }, 500);
  }

  onEvaluateResultGridColumnResized(event) {
    if (event.finished) {
      this.evaluateResultGridApi.resetRowHeights();
    }
  }

  onEvaluateResultGridPageChange(number: number) {
    this.evaluateResultGridPagingConfig.currentPage = number;
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
    this.evaluateResultGridPagingConfig.currentPage = 1;
  }

  downloadFile(headerName, data) {
    var filePath: string;
    if (headerName == 'Resume') {
      filePath = data.resumeFilePath;
    }
    else if (headerName == 'Recording') {
      filePath = data.recordingFilePath;
    }
    if (filePath != null) {
      const a = document.createElement('a');
      a.style.display = 'none';
      a.href = this.webAPIDownloadResumeUrl + filePath;
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
      this.evaluateResultGridPagingConfig.currentPage = 1;
    });
  }

  onCancel() {
    this.operationMode = OperationMode.View;
    this.evaluateResultGridPagingConfig.currentPage = 1;
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
}    
