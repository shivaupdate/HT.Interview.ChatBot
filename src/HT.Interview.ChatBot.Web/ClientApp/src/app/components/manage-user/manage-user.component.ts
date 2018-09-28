import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../../models/user';
import { Role } from '../../models/role';
import { Gender } from '../../models/gender';
import { Profile } from '../../models/profile';
import { RoleEnum } from '../../models/enums';
import { GenderEnum } from '../../models/enums';
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
  private profileSelect: any; 
  private user: User;
  formData: FormData = new FormData();

  private paginationPageSize = environment.application.pageSize;
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getMany;
  private webAPICreateUserUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.create;
  private webAPIGetRoleUrl = environment.application.webAPIUrl + environment.controller.roleController + environment.action.getMany;
  private webAPIGetGenderUrl = environment.application.webAPIUrl + environment.controller.genderController + environment.action.getMany;
  private webAPIGetProfileUrl = environment.application.webAPIUrl + environment.controller.profileController + environment.action.getMany;

  constructor(private http: HttpClient) {
    this.columnDefs = [
      { headerName: "Role", field: "roleName", filter: 'agTextColumnFilter' },
      { headerName: "Name", field: "displayName", suppressSizeToFit: true, filter: 'agTextColumnFilter' },
      { headerName: "Email", field: "email", suppressSizeToFit: true, filter: 'agDateColumnFilter' },
      { headerName: "Mobile", field: "mobile", filter: 'agTextColumnFilter' },
      { headerName: "Gender", field: "genderName", filter: 'agDateColumnFilter' },
      { headerName: "Provider", field: "provider", filter: 'agTextColumnFilter' },
      {
        headerName: "Is Active", field: "isActive",
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
      { id: 1, name: "Candidate" }
    ];;
          
    this.http.get(this.webAPIGetProfileUrl)
      .subscribe(data => {
        this.profileSelect = data;
        console.log(this.profileSelect);
      });

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

  addUser() {
    this.user.genderId = GenderEnum.Unknown;
    this.user.roleId = RoleEnum.Candidate;
    this.user.jobProfileId = 1;
    this.operationMode = true;
  }

  uploadFile(event) {
    let files = event.target.files;
    if (files.length > 0) {
      for (let file of files)
        this.formData.append('resumeFile', file, file.name);
    }
  }

  onSave() {
    this.formData.append('firstName', this.user.firstName);
    this.formData.append('lastName', this.user.lastName);
    this.formData.append('email', this.user.email);
    this.formData.append('mobile', String(this.user.mobile));
    this.formData.append('genderId', String(this.user.genderId));
    this.formData.append('roleId', String(this.user.roleId));
    this.formData.append('jobProfileId', String(this.user.jobProfileId));
    this.formData.append('isActive', String(true));
    this.formData.append('createdBy', 'RavindraK@hexaware.com');

    this.http.post(this.webAPICreateUserUrl, this.formData).subscribe(data => {
      this.user = new User();
      this.operationMode = false;
    })
  }

  onCancel() {
    this.operationMode = false;
  }
}             
