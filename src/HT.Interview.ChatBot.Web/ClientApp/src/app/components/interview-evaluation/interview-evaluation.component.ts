import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
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
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getMany;
  private paginationPageSize = environment.application.pageSize;

  constructor(private http: HttpClient) {
    this.columnDefs = [
      {
        headerName: "Profile Applied For",
        field: "jobProfileType",
        suppressSizeToFit: true
      },
      {
        headerName: "Applied Date",   
        suppressSizeToFit: false
      },
      {
        headerName: "Name",
        field: "displayName",
        suppressSizeToFit: false
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
        headerName: "Remark" 
      },
      {
        headerName: "End Result" 
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

    this.http.get(this.webAPIUrl)
      .subscribe(data => {
        this.rowData = data;
      });
  }
}    
