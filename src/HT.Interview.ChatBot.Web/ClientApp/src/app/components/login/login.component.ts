import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";           
import { AuthService, FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from '../../../environments/environment';
import { User } from '../../models/user';
import { Constants } from '../../models/constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  private getUserWebAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getWithParameters;
  private updateUserWebAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.update;
  private constants = new Constants();

  constructor(private route: ActivatedRoute, private router: Router, private socialAuthService: AuthService, private http: HttpClient) { }
  returnUrl: string;

  ngOnInit() {
    localStorage.removeItem(this.constants.applicationUser);
    localStorage.removeItem(this.constants.socialUser);
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  socialSignIn(socialPlatform: string) {
    let socialPlatformProvider;
    if (socialPlatform == "facebook") {
      socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
    } else if (socialPlatform == "google") {
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    }
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (socialUser) => {
        this.http.get<User>(this.getUserWebAPIUrl + 'email=' + socialUser.email)
          .subscribe(
            applicationUser => {
              applicationUser.photoUrl = socialUser.photoUrl;
              applicationUser.socialAccountInfo = JSON.stringify(socialUser);

              var body = JSON.stringify(applicationUser);     

              var httpOptions = {
                headers: new HttpHeaders({
                  'Content-Type': 'application/json'
                })
              };

              this.http.put(this.updateUserWebAPIUrl, body, httpOptions).subscribe(data => {
                localStorage.setItem(this.constants.applicationUser, JSON.stringify(applicationUser));
                localStorage.setItem(this.constants.socialUser, JSON.stringify(socialUser));    
                this.router.navigate([this.returnUrl]);  
              });

            },
            error => {
              console.log(error)
            });
      }
    );
  }
}