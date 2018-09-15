import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public message: string;
  constructor() { }

  ngOnInit() {
    this.message= "Your last visit was: 05-09-2018 18:26";
  }

}
