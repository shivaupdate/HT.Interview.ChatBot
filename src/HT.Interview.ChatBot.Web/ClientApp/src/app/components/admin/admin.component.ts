import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise'; 
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { UserService } from "../../services/socialuser.service";
import {GoogleUser} from "../../models/googleuser.model";
import { SearchPipe } from "../../models/search.pipe";


@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  emailAddressInvalid: boolean;
  emailPattern: string;

  editMode: boolean;
  emailIdOfAnalyst: string;
  roleOfAnalyst: string;
  selectedRole: Role;
  selectedEngagementID: number;
  alertMessage: string;
  emailExists: string;
  emailStatus: string;

  userRoles: Role[];
  userRolesList : Role[];
  userList: GoogleUser[];
  showDropDown = false;
  editRole: Role;
  searchText: string;

 
  constructor(private http:Http, private authService: AuthService, public userService: UserService) { 
    this.selectedRole = new Role();
    this.editRole = new Role();
  }

  ngOnInit() {   

    console.log('Admin module');

    this.userRolesList = [
      {
        ID: 1,
        RoleName : "Admin"
      },
      {
        ID: 2,
        RoleName : "Human Resource"        
      },
      {
        ID: 3,
        RoleName : "Candidate"
      },
      {
        ID: 4,
        RoleName: "Panelist"
      }

    ];

    console.log(this.userService.userList);

    this.userList = this.userService.userList;
    
  /*   

  this.http.get("http://localhost:56072/api/user")
        .map((data: Response) => {
          return data.json() as User[];
        }).toPromise().then(x => {
          this.userList = x;
          
          this.userList.forEach(x=>x.editMode = false);

        });
   */  
  }


  clearUser()
  {
    this.emailIdOfAnalyst = "";
    //this.
  }
  AddUser()
  {
    
      console.log(this.emailIdOfAnalyst);
      let userCount = this.userList.length;
      let newUser = new User();
      newUser.editMode = false;
      newUser.Email = this.emailIdOfAnalyst;
      newUser.RoleId = this.selectedRole.ID;
      newUser.ID = userCount + 1;

      //this.userList.push(newUser);

      var body = JSON.stringify(newUser);
      var headerOptions = new Headers({ 'Content-Type': 'application/json'});
      var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
      this.http.post('http://localhost:50463/api/v1/candidate', body, requestOptions).map(x => x.json()).subscribe(data => {
      
        console.log('User added sucessfully...');
      });

      this.selectedRole.ID = -1;
      this.emailIdOfAnalyst = "";

      console.log(this.userList);
  }

  editUser(user:GoogleUser)
  {
    
    user.editMode= true;
    
  }

  saveUserChanges(user:GoogleUser)
  {
    user.roleId = this.editRole.ID;
    user.editMode = false;

    console.log(user);

    var body = JSON.stringify(user);
    var headerOptions = new Headers({ 'Content-Type': 'application/json'});
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    this.http.put('http://localhost:50463/api/v1/candidate', body, requestOptions).map(x => x.json()).subscribe(data => {
      
      console.log('User has been updated sucessfully...');
    });
  }

  DeleteUser(user:GoogleUser)
  {
    console.log('Delete User');
    console.log(user);
    var body = JSON.stringify(user);

    let id = this.userService.userList.findIndex(x=>x.email == user.email);
    console.log(id);
    var headerOptions = new Headers({ 'Content-Type': 'application/json'});
    var requestOptions = new RequestOptions({ method: RequestMethod.Delete, headers: headerOptions, body:body });
    this.http.delete('http://localhost:50463/api/v1/candidate', requestOptions).map(x => x.json()).subscribe(data => {
      
      id = this.userService.userList.findIndex(x=>x.email == user.email);
      this.userService.userList.splice(id,1);
      console.log('User has been deleted sucessfully...');
    });
  }

  cancelUserChanges(user:GoogleUser)
  {
    
    user.editMode = false;
  }

  AddNewUser(userManagementForm:NgForm){

  }

  onChange(event) {
    this.selectedRole.RoleName = event as string;
  }

  onChangeRole(event) {
    this.selectedRole.RoleName = event as string;
  }

  
}


export class Role {
  ID: number;
  RoleName: string;
  
}

export class User {
  ID: number;
  Email: string; 
  editMode: boolean;
  RoleId: number;
  Name: string;  
}

