import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";           
import { AuthService, FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from '../../../environments/environment';
import { User } from '../../models/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  private getUserWebAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.getWithParameters;
  private updateUserWebAPIUrl = environment.application.webAPIUrl + environment.controller.userController + environment.action.update;

  constructor(private route: ActivatedRoute, private router: Router, private socialAuthService: AuthService, private http: HttpClient) { }
  returnUrl: string;

  ngOnInit() {
    localStorage.removeItem('currentUser');
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
      (socialUserAccount) => {
        this.http.get<User>(this.getUserWebAPIUrl + 'email=' + socialUserAccount.email)
          .subscribe(
            applicationUser => {
              applicationUser.photoUrl = socialUserAccount.photoUrl;
              applicationUser.socialAccountInfo = JSON.stringify(socialUserAccount);

              var body = JSON.stringify(applicationUser);
              console.log(body);

              var httpOptions = {
                headers: new HttpHeaders({
                  'Content-Type': 'application/json'
                })
              };
              //var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });

              this.http.put(this.updateUserWebAPIUrl, body, httpOptions).subscribe(data => {
                localStorage.setItem('currentUser', JSON.stringify(socialUserAccount));    
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
