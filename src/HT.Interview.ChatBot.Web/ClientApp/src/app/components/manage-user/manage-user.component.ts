import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from '../../../environments/environment';
import {User} from '../../models/user';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';

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
  private userList: User[];
  private addUser: boolean;
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getMany;
  private webAPIudate = environment.application.webAPIUrl + environment.controller.userController + environment.action.update;
  private paginationPageSize = environment.application.pageSize;

  private userRolesList: Role[];
  private selectedRole : Role;
  private selectedRoleForAdd : Role;
  private editRole: Role;
  private addRole:Role;

  private email: string;
  private firstName:string;
  private lastName:string;
  private role:string;
  private mobile:string;
  private provider: string;
  private genderSelect: Gender[];

  constructor(private http: HttpClient) {
    this.editRole = new Role();
    this.addRole = new Role();
    this.selectedRole = new Role();
    this.selectedRoleForAdd = new Role();
    this.columnDefs = [
      {
        headerName: "Role",
        field: "name",
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
      }//,
      //{
      //  cellRenderer: params => {
      //    return `<span><i class="fa fa-edit" style="color:green; cursor: pointer;"></i></span>&nbsp;&nbsp;&nbsp;<span><i class="fa fa-trash" style="color:#e15555; cursor: pointer;"></i></span>`;
      //  }
      //}
    ];
  }

  ngOnInit() {
    this.http.get(this.webAPIUrl)
    .subscribe(data => {
      this.rowData = data as User[]; 
      this.userList = data as User[];
      this.addUser = false;
      this.provider = 'GOOGLE';

      //this.roleSelect = [
      //  { Id: '1', RoleName: 'Candidate' },
      //  { Id: '2', RoleName: 'Admin' },
      //  { Id: '3', RoleName: 'HR' },
      //  { Id: '4', RoleName: 'Panel' } 
      //];

      this.genderSelect = [
        { Id: 1, Name: 'Unknown' },
        { Id: 2, Name: 'Male' },
        { Id: 3, Name: 'Female' }  
      ];

      this.userRolesList = [
        {
          Id: 1,
          Name : "Candidate"
        },
        {
          Id: 2,
          Name : "Admin"        
        },
        {
          Id: 3,
          Name : "HR"
        },
        {
          Id: 4,
          Name: "Panel"
        }
  
      ];
      
      console.log('Grid Data...');
      console.log(this.userList[0].mobile)          ;
    });
  }      

  onFirstDataRendered(params) {
    params.api.sizeColumnsToFit();
  }

  onChange(event) {
    this.selectedRoleForAdd.Id = event as number;
  }

  onChangeRole(event) {
    this.selectedRole.Id = event as number;
  }

  OnOK()
  {
    this.addUser = false;

    let user = new User();
    user.email = this.email;
    user.firstName = this.firstName;
    user.lastName = this.lastName;
    user.mobile = Number(this.mobile);
    user.provider = this.provider;
    console.log(this.provider);
    user.roleId = this.selectedRoleForAdd.Id;
  //  user.name = this.userRolesList[user.roleId as number -1].RoleName

    this.userList.push(user);
    


  }

  OnCancel()
  {
    this.addUser = false;
  }

  AddUser()
  {
    this.addUser = true;
    this.selectedRoleForAdd.Id = -1;
    this.addRole.Id = -1;
    this.selectedRoleForAdd.Name = '';   
  }

  editUser(user:User)
  {    
  // user.editMode= true;
    this.editRole.Id = this.userRolesList.findIndex(x => x.Name == user.Name) +1 ;    
  }

  saveUserChanges(user:User)
  {
    user.roleId = this.selectedRole.Id;
  //  user.name = this.userRolesList[this.selectedRole.Id-1].RoleName;
    console.log('This user role is:');
    console.log(this.editRole);
   // user.editMode = false;

    console.log('Updated user:');
    console.log(user);
    var body = JSON.stringify(user);
    const httpOptions = {
      headers: new HttpHeaders({
      'Content-Type':  'application/json'      
     })
 };
 
    //var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    this.http.put(this.webAPIudate, body, httpOptions).subscribe(data => {
      
      console.log('User has been updated sucessfully...');
    });
  }

  DeleteUser(user:User)
  {
    
  }

  cancelUserChanges(user:User)
  {
    
    //user.editMode = false;
  }


  onGridReady(params) {
    this.gridApi = params.api;
    this.gridColumnApi = params.columnApi;

    this.http.get(this.webAPIUrl)
      .subscribe(data => {
        this.rowData = data as User[]; 
        this.userList = data as User[];
        
        console.log('Grid Data...');
        console.log(this.userList)          ;
      });
  }
}    

export class Role {
  Id: number;
  Name: string;
  
}

export class Gender {
  Id: number;
  Name: string;          
}
