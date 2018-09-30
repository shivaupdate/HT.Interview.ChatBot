import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../../models/user';
import { Constants } from '../../models/constants';
import { GridAddButtonComponent } from '../custom/grid-add-button/grid-add-button.component';
import { DownloadFileComponent } from '../custom/download-file/download-file.component';
import { RoleEnum } from '../../models/enums';
import { OperationMode } from '../../models/enums';
import { GridOptions } from "ag-grid-community";
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-interview-evaluation',
  templateUrl: './interview-evaluation.component.html',
  styleUrls: ['./interview-evaluation.component.css']
})
export class InterviewEvaluationComponent implements OnInit {

  private viewGridOptions: GridOptions;
  private evaluateGridOptions: GridOptions;
  private viewGridColumns;
  private evaluateGridColumns;
  private viewGridData: any;
  private evaluateGridData: any;

  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getManyByRoleId + '?roleId=' + RoleEnum.Candidate;
  private webAPIGetInterviewDetailUrl = environment.application.webAPIUrl + environment.controller.interviewController + environment.action.getInterviewDetailByUserId + '?userId=';
  private webAPIUpdateUserInterviewResultUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.updateUserInterviewResult;
  private webAPIDownloadResumeUrl = environment.application.webAPIUrl + environment.controller.downloadController + environment.action.getWithParameters + 'filePath=';

  private paginationPageSize = environment.application.pageSize;
  private user = new User();
  private constants = new Constants();
  private loggedInUser = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));
  private operationMode: OperationMode = OperationMode.View;
  private endResultSelect: any;

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
      { headerName: "Profile Name", field: "profileName", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 200 },
      {
        headerName: "Interview Date", field: "interviewDate", suppressSizeToFit: false, filter: 'agDateColumnFilter',
        cellRenderer: (data) => {
          return data.value ? (new Date(data.value)).toLocaleDateString() : '';
        },
        width: 150
      },
      { headerName: "Candidate Name", field: "displayName", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 280 },
      {
        headerName: "Resume",
        suppressSizeToFit: false,
        cellRendererFramework: DownloadFileComponent,
        width: 100
      },
      { headerName: "Remark", filter: 'agTextColumnFilter', field: "remark", width: 500 },
      { headerName: "End Result", filter: 'agTextColumnFilter', field: "endResult", width: 200 },
      {
        headerName: "Evaluate",
        cellRendererFramework: GridAddButtonComponent,
        width: 100
      }
    ];

    this.evaluateGridColumns = [
      {
        headerName: "SN", field: "rowNumber", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 60,
        cellRenderer: params => { return `<div style="text-align:center;"> ${params.value}</div>`; }
      },
      { headerName: "Bot Response", field: "botResponse", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 530 },
      { headerName: "User Reponse", field: "userResponse", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 500 },
      { headerName: "Expected Answer", field: "expectedAnswer", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 180 },
      {
        headerName: "Allocated Time", field: "allocatedTime", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 120,
        valueFormatter: this.timeFormatter     
      },
      {
        headerName: "Time Taken", field: "timeTaken", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 120,
        valueFormatter: this.timeFormatter,
        cellClass: ['time-cell']     
      }
    ];
  }

  onViewGridReady() {
    this.http.get(this.webAPIUrl)
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

    // this.viewGridOptions.api.setDatasource(this.onEvaluateGridLoad());
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
}    
