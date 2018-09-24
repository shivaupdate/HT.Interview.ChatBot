import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { User } from '../../models/user';
import { Role } from '../../models/enums';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-interview-evaluation',
  templateUrl: './interview-evaluation.component.html',
  styleUrls: ['./interview-evaluation.component.css']
})
export class InterviewEvaluationComponent implements OnInit {

  private gridApi;
  private gridColumnApi;
  private columnDefs;
  private rowData: any;
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + '/get-candidate-many';
  private paginationPageSize = environment.application.pageSize;
  private user = new User();

  constructor(private http: HttpClient) {
    this.columnDefs = [
      {
        headerName: "Profile Name",
        field: "profileName",
        suppressSizeToFit: true,
        filter: 'agTextColumnFilter'   
      }, 
      {
        headerName: "Interview Date",
        field: "interviewDate",
        suppressSizeToFit: false,
        filter: 'agDateColumnFilter' 
      },
      {
        headerName: "Name",
        field: "displayName",
        suppressSizeToFit: false,
        filter: 'agTextColumnFilter' 
      },
      {
        headerName: "Resume",
        suppressSizeToFit: false,     
        cellRenderer: params => {
          return `<div style="text-align:center;"><i class="fa fa-file" style="color:black; cursor: pointer;"></i></div>`;
        }
      },
      {
        headerName: "Q & A",    
        cellRenderer: params => {
          return `<div style="text-align:center;"><i class="fa fa-eye" style="color:black; cursor: pointer;"></i></div>`;
        }
      },
      {
        headerName: "Remark",
        filter: 'agTextColumnFilter',
        field: "remark"
      },
      {
        headerName: "End Result",
        filter: 'agTextColumnFilter',
        field: "endResult"
      }
    ];
  }

  ngOnInit() {
  }

  onFirstDataRendered(params) {
    params.api.sizeColumnsToFit();
  }

  onGridReady(params) {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;

    this.http.get(this.webAPIUrl + '?roleId = 2')
      .subscribe(data => {
        this.rowData = data;
      });
  }

}    
