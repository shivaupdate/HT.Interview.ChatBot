import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../../models/user';
import { Role } from '../../models/role';
import { Gender } from '../../models/gender';    
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-manage-user',
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.css']
})
export class ManageUserComponent implements OnInit {

  private columnDefs;
  private rowData: any;      
  private operationMode: boolean;
  private roleSelect: Role[];
  private genderSelect: Gender[];
  private user: User;

  private paginationPageSize = environment.application.pageSize;
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getMany;
  private webAPICreateUserUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.create;

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
      }
    ];
  }

  ngOnInit() {             
    this.user = new User();
    this.genderSelect = [
      { id: 1, name: 'Unknown' },
      { id: 2, name: 'Male' },
      { id: 3, name: 'Female' }
    ];

    this.roleSelect = [
      { id: 1, name: "Candidate" },
      { id: 2, name: "Admin" },
      { id: 3, name: "HR" },
      { id: 4, name: "Panel" }
    ];;

    this.http.get(this.webAPIUrl)
      .subscribe(data => {
        this.operationMode = false;
      });
  }

  onFirstDataRendered(params) {
    params.api.sizeColumnsToFit();
  }

  onGridReady() {
    this.http.get(this.webAPIUrl)
      .subscribe(data => {
        this.rowData = data;
      });
  }

  onSave() {
    this.user.isActive = true;
    this.user.createdBy = "RavindraK@hexaware.com";
    var body = JSON.stringify(this.user);
    console.log(this.webAPICreateUserUrl);
    console.log(body);
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.http.post(this.webAPICreateUserUrl, body, httpOptions).subscribe(data => {
      this.user = new User();
      this.operationMode = false;
    })
  }

  onCancel() {
    this.operationMode = false;
  }

  addUser() {
    this.operationMode = true;
  }
}             
