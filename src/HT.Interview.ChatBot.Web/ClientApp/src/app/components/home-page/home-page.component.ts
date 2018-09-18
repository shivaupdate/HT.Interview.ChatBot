import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';
import { NavigationComponent } from '../navigation-component/navigation.component';
import { UserService } from '../../services/socialuser.service'

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(public userService: UserService) { }

  ngOnInit() {
    console.log('Active Module:' + this.userService.activeModule)
  }

}
