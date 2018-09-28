import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../../models/user';
import { Constants } from '../../models/constants';
import { GridButtonComponent } from '../grid-button/grid-button.component';
import { DownloadFileComponent } from '../download-file/download-file.component';
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
  private viewGridColumns;
  private evaludateGridColumns;
  private viewGridData: any;
  private evaluateGridData: any;

  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getManyByRoleId + '?roleId=' + RoleEnum.Candidate;
  private webAPIGetInterviewDetailUrl = environment.application.webAPIUrl + environment.controller.interviewController + environment.action.getInterviewDetailByUserId + '?userId=' + 2;
  private webAPIUpdateUserInterviewResultUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.updateUserInterviewResult;
  private webAPIDownloadResumeUrl = environment.application.webAPIUrl + environment.controller.downloadController + environment.action.getWithParameters + 'filePath=';

  private paginationPageSize = environment.application.pageSize;
  private user = new User();
  private constants = new Constants();
  private loggedInUser = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));
  private operationMode: OperationMode = OperationMode.View;
  private endResultSelect: any;

  constructor(private http: HttpClient) {

    this.viewGridOptions = <GridOptions>{
      columnDefs: this.viewGridColumns,
      context: {
        componentParent: this
      }
    };

    this.viewGridColumns = [
      { headerName: "Profile Name", field: "profileName", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 187 },
      {
        headerName: "Interview Date", field: "interviewDate", suppressSizeToFit: false, filter: 'agDateColumnFilter',
        cellRenderer: (data) => {
          return data.value ? (new Date(data.value)).toLocaleDateString() : '';
        },
        width: 130
      },
      { headerName: "Name", field: "displayName", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 200 },
      {
        headerName: "Resume",
        suppressSizeToFit: false,
        cellRendererFramework: DownloadFileComponent,
        width: 100
      },
      { headerName: "Remark", filter: 'agTextColumnFilter', field: "remark", width: 300 },
      { headerName: "End Result", filter: 'agTextColumnFilter', field: "endResult", width: 200 },
      {
        headerName: "Evaluate",
        cellRendererFramework: GridButtonComponent,
        width: 100
      }
    ];

    this.evaludateGridColumns = [
      {
        headerName: "SN", field: "rowNumber", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 60,
        cellRenderer: params => { return `<div style="text-align:center;"> ${params.value}</div>`; }
      },
      { headerName: "Bot Response", field: "botResponse", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 500 },
      { headerName: "User Reponse", field: "userResponse", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 500 },
      { headerName: "Expected Answer", field: "expectedAnswer", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 150 },
      {
        headerName: "Allocated Time", field: "allocatedTime", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 150,
        cellRenderer: params => { return `<div style="text-align:center;"> ${params.value}</div>`; }
      },
      {
        headerName: "Time Taken", field: "timeTaken", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 150,
        cellRenderer: params => { return `<div style="text-align:center;"> ${params.value}</div>`; }
      }
    ];
  }

  ngOnInit() {
    this.user = new User();

    this.endResultSelect = [
      { id: "Selected", name: "Selected" },
      { id: "Not Selected", name: "Not Selected" },
      { id: "On Hold", name: "On Hold" },
      { id: "Required further evaluation", name: "Required Further Evaluation" }
    ];;
  }

  onFirstDataRendered(params) {
    //params.api.sizeColumnsToFit();
  }

  onViewGridReady() {
    this.http.get(this.webAPIUrl)
      .subscribe(data => {
        this.viewGridData = data;
      });
  }

  onEvaluateGridReady() {
    this.http.get(this.webAPIGetInterviewDetailUrl)
      .subscribe(data => {
        this.evaluateGridData = data;
      });
  }

  showEvaluateGrid(userId, remark, endResult) {
    this.user.id = userId;         
    if (endResult == null) {
      this.user.endResult = "On Hold";
    }
    else {
      this.user.endResult = endResult;
    }
    this.user.remark = remark;
    this.operationMode = OperationMode.Edit;
  }

  downloadFile(filePath) {
    console.log(filePath);
    const file = this.http.get<Blob>(this.webAPIDownloadResumeUrl + filePath, { responseType: 'blob' as 'json' })   
    const a = document.createElement('a');
    a.style.display = 'none';
    a.href = this.webAPIDownloadResumeUrl + filePath;
    a.download = "test";
    document.body.appendChild(a);     
    a.click();
    setTimeout(() => {
      document.body.removeChild(a);       
    }, 100);       
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
}    
