import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/socialuser.service';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-social-user-profile',
  templateUrl: './social-user-profile.component.html',
  styleUrls: ['./social-user-profile.component.css']
})
export class SocialUserProfileComponent implements OnInit {

  constructor(public userService: UserService, private http: Http, private router: Router) { }

  public firstName: string;
  public lastName: string;

  ngOnInit() {

  }

  CreateUser() {
    var body = JSON.stringify(this.userService.googleUser);
    console.log(body);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
    console.log('Before calling user addition...');
    this.http.post('http://localhost:50463/api/v1/candidate', body, requestOptions).subscribe(data => {

      this.userService.loggedIn = true;
      console.log('User created successfully...');
      this.router.navigate(['home']);

    });

  }

  CancelUser() {
    this.userService.loggedIn = false;
    this.userService.googleUser = null;
    this.router.navigate(['home']);
  }
}
