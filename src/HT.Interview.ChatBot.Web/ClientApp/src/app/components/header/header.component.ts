import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { AuthService, SocialUser } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { GoogleUser } from '../../models/googleuser.model';
import { Roles} from '../../models/roles.enum';
import { Router } from '@angular/router';
import { UserService } from '../../services/socialuser.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  public socialUser: SocialUser;
  public loggedIn: boolean;
  public googleUser: GoogleUser;
  public userList: GoogleUser[];

  constructor(private authService: AuthService,private http:Http, private router:Router, public userService: UserService) { }

  ngOnInit() {

    this.authService.authState.subscribe((user) => {
      if(this.userService.loggedIn == true)
      {
        this.socialUser = user as SocialUser;
        this.loggedIn = (user != null);
        if(this.socialUser != null ) {
          console.log('Before calling user list...');
          this.http.get("http://localhost:50463/api/v1/candidate/get")
          .map((data: Response) => {
            return data.json() as GoogleUser[];
          }).toPromise().then(x => {
            this.userList = x;          
            this.userList.forEach(x=>x.editMode = false);
            this.userService.userList = this.userList;

            this.googleUser = new GoogleUser();
            this.googleUser.email = this.socialUser.email;
            this.googleUser.firstName = this.socialUser.firstName;
            this.googleUser.lastName = this.socialUser.lastName;
            this.googleUser.name = this.socialUser.name;
            this.googleUser.photoUrl = this.socialUser.photoUrl;
            this.googleUser.roleId = Roles.Candidate;
            this.googleUser.editMode = false;
    
            this.userService.googleUser = this.googleUser;

            let userTemp : GoogleUser;
            if((userTemp = this.userList.find(x=>x.email == this.socialUser.email)) != null )
            {
                console.log('User already exists...');   
                this.userService.googleUser = userTemp;
                console.log(this.userService.googleUser);

                this.userService.loggedIn = true;            
                this.userService.userList = this.userList;
                        
            }
            else
            {
              this.router.navigate(['socialprofile']);
              
            }   

          });
        
        }

        console.log('Google user:');
        console.log(this.googleUser);
        }
      });   
    
  }

  socialSignIn()
  {
    console.log('Social user clicked...');
    this.userService.loggedIn = true;
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  EnableDashboard()
  {
    this.userService.activeModule = "Dashboard";
    console.log('Dashboard Enabled');
  }

  EnableAdmin()
  {
    this.userService.activeModule = "Admin";
  }

  EnableAgent()
  {
    this.userService.activeModule = "ChatBot";
  }
}
