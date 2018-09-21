import { Component, OnInit } from '@angular/core';
import { AuthService, FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";    
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  constructor(private route: ActivatedRoute,  private router: Router, private socialAuthService: AuthService) { }
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
    console.log(socialPlatform);
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (user) => {
        console.log(socialPlatform + " sign in data : ", user);
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.router.navigate([this.returnUrl]);
      }
    );
  }
}
