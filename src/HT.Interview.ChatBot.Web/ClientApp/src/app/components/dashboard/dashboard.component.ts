import { Component, OnInit } from '@angular/core';
import { UserService } from "../../services/socialuser.service";
import { GoogleUser } from "../../models/googleuser.model";


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  userList: GoogleUser[];
  userRolesList: Role[];
  public message: string;
  display = 'none';

  constructor(public userService: UserService) { }

  ngOnInit() {
    this.userRolesList = [
      {
        ID: 1,
        RoleName: "Admin"
      },
      {
        ID: 2,
        RoleName: "Human Resource"
      },
      {
        ID: 3,
        RoleName: "Candidate"
      },
      {
        ID: 4,
        RoleName: "Panelist"
      }

    ];
    this.userList = this.userService.userList;
    this.message = "Your last visit was: 05-09-2018 18:26";
  }
}

export class Role {
  ID: number;
  RoleName: string;
}
