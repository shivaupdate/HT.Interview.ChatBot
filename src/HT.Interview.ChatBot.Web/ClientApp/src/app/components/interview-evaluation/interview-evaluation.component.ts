import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { User } from '../../models/user';
import { RoleEnum } from '../../models/enums';
import { OperationMode } from '../../models/enums';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-interview-evaluation',
  templateUrl: './interview-evaluation.component.html',
  styleUrls: ['./interview-evaluation.component.css']
})
export class InterviewEvaluationComponent implements OnInit {

  private viewGridColumns;
  private evaludateGridColumns;
  private viewGridData: any;
  private evaluateGridData: any;
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getManyByRoleId + '?roleId=' + RoleEnum.Candidate;
  private webAPIGetInterviewDetailUrl = environment.application.webAPIUrl + environment.controller.interviewController + environment.action.getInterviewDetailByUserId + '?userId=' + 2;
  private paginationPageSize = environment.application.pageSize;
  private user = new User();
  private operationMode: OperationMode = OperationMode.Edit;

  constructor(private http: HttpClient) {
    this.viewGridColumns = [
      { headerName: "Profile Name", field: "profileName", suppressSizeToFit: true, filter: 'agTextColumnFilter' },
      {
        headerName: "Interview Date", field: "interviewDate", suppressSizeToFit: false, filter: 'agDateColumnFilter',
        cellRenderer: (data) => {
          return data.value ? (new Date(data.value)).toLocaleDateString() : '';
        }
      },
      { headerName: "Name", field: "displayName", suppressSizeToFit: false, filter: 'agTextColumnFilter' },
      {
        headerName: "Resume",
        suppressSizeToFit: false,
        cellRenderer: params => {
          return `<div style="text-align:center;"><i class="fa fa-file" style="color:black; cursor: pointer;"></i></div>`;
        }
      },
      { headerName: "Remark", filter: 'agTextColumnFilter', field: "remark" },
      { headerName: "End Result", filter: 'agTextColumnFilter', field: "endResult" },
      {
        headerName: "Evaluate",
        cellRenderer: params => {
          return `<div style="text-align:center;"><i class="fa fa-trophy" style="color:black; cursor: pointer;"></i></div>`;
        }
      }
    ];

    this.evaludateGridColumns = [
      { headerName: "SN", field: "rowNumber", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 60 },
      { headerName: "Bot Response", field: "botResponse", suppressSizeToFit: true, filter: 'agTextColumnFilter', width: 500  },
      { headerName: "User Reponse", field: "userResponse", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 500  },
      { headerName: "Expected Answer", field: "expectedAnswer", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 150 },
      { headerName: "Allocated Time", field: "allocatedTime", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 150 },
      { headerName: "Time Taken", field: "timeTaken", suppressSizeToFit: false, filter: 'agTextColumnFilter', width: 150 }
    ];
  }

  ngOnInit() {
  }

  onFirstDataRendered(params) {
    params.api.sizeColumnsToFit();
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
}    
