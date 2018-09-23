import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-manage-user',
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.css']
})
export class ManageUserComponent implements OnInit {

  private gridApi;
  private gridColumnApi;
  private columnDefs;
  private rowData: any;
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getMany;
  private paginationPageSize = environment.application.pageSize;

  constructor(private http: HttpClient) {
    this.columnDefs = [
      {
        headerName: "Role",
        field: "roleName",
        filter: 'agTextColumnFilter'
      },
      {
        headerName: "Name",
        field: "displayName",
        suppressSizeToFit: true,
        filter: 'agTextColumnFilter'
      },
      {
        headerName: "Email",
        field: "email",
        suppressSizeToFit: true,
        filter: 'agDateColumnFilter'
      },
      {
        headerName: "Mobile",
        field: "mobile",
        filter: 'agTextColumnFilter'
      },
      {
        headerName: "Gender",
        field: "genderName",
        filter: 'agDateColumnFilter'
      },
      {
        headerName: "Provider",
        field: "provider",
        filter: 'agTextColumnFilter'
      },
      {
        headerName: "Is Active",
        field: "isActive",
        cellRenderer: params => {
          return `<div style='text-align:center;'><input disabled type='checkbox' ${params.value ? 'checked' : ''} /></div>`;
        }
      },
      {
        cellRenderer: params => {
          return `<span><i class="fa fa-edit" style="color:green; cursor: pointer;"></i></span>&nbsp;&nbsp;&nbsp;<span><i class="fa fa-trash" style="color:#e15555; cursor: pointer;"></i></span>`;
        }
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