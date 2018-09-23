import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Constants } from '../../../models/constants';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})

export class HeaderComponent {

  private constants = new Constants();

  constructor(private router: Router) {
  }



  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem(this.constants.applicationUser);
    localStorage.removeItem(this.constants.socialUser);
    this.router.navigate(['login']);
  }
}
