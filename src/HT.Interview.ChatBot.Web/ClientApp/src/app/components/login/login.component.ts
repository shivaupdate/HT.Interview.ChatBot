import { Component, OnInit } from '@angular/core';
import { AuthService, SocialUser, FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { concat } from 'rxjs/operator/concat';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  constructor(private socialAuthService: AuthService) { }

  ngOnInit() {

  }

  socialSignIn(socialPlatform: string) {
    let socialPlatformProvider;
    if (socialPlatform == "facebook") {
      socialPlatformProvider = FacebookLoginProvider.PROVIDER_ID;
    } else if (socialPlatform == "google") {
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    }
    console.log(socialPlatform);
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        console.log(socialPlatform + " sign in data : ", userData);

      }
    );
  }
}
