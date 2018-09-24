import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Constants } from '../../../models/constants';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})

export class HeaderComponent {

  private constants = new Constants();
  private user = JSON.parse(localStorage.getItem(this.constants.applicationUser));

  constructor(private router: Router) {

    //this.http.get<User>(this.getUserWebAPIUrl + 'email=' + socialUser.email)
    //  .subscribe(
    //    accessMatrix => { });
  }



  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem(this.constants.applicationUser);        
    this.router.navigate(['login']);
  }
}
