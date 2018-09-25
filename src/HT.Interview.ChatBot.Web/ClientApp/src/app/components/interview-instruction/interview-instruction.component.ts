import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-interview-instruction',
  templateUrl: './interview-instruction.component.html',
  styleUrls: ['./interview-instruction.component.css']
})
export class InterviewInstructionComponent implements OnInit {
     
  constructor(private http: HttpClient) {
  }

  ngOnInit() {
  }
             
}    
