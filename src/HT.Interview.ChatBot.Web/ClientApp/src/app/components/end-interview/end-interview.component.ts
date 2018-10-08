import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Constants } from '../../models/constants';

@Component({
  selector: 'app-end-interview',
  templateUrl: './end-interview.component.html',
  styleUrls: ['./end-interview.component.css']
})

export class EndInterviewComponent {
  private constants = new Constants();
  private user = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));
  
  constructor() {
    sessionStorage.removeItem(this.constants.applicationUser);
    sessionStorage.clear();
  }             
}    
