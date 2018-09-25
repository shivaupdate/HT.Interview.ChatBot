import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Constants } from '../../../models/constants';
import { forEach } from '@angular/router/src/utils/collection';
import { retry } from 'rxjs/operator/retry';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})

export class HeaderComponent {

  private constants = new Constants();
  private user = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));

  constructor(private router: Router) {

  }

  hasAccess(claimName) {   
    let userClaims = this.user.claims;
    console.log(userClaims);
    let hasAccess = false;
    userClaims.forEach(function (userClaim) {  
      if (userClaim.claimName === claimName) {
        if (userClaim.value === 'True') {
          hasAccess = true;
        }              
      }   
    });  
    return hasAccess;
  }

  logout() {
    // remove user from local storage to log user out
    sessionStorage.removeItem(this.constants.applicationUser);
    sessionStorage.clear();
    this.router.navigate(['login']);
  }
}
