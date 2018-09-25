import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Constants } from '../../../models/constants';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})

export class HeaderComponent {

  private constants = new Constants();
  private user = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));

  constructor(private router: Router) {
          
  }



  logout() {
    // remove user from local storage to log user out
    sessionStorage.clear(); 
    this.router.navigate(['login']);
  }
}
