import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';
import { GoogleUser } from '../models/googleuser.model';

@Injectable()
export class UserService {

  public googleUser : GoogleUser;
  public loggedIn: boolean;
  public userList : GoogleUser[];
  public activeModule:string;
  constructor(private http: Http ) {
    this.googleUser = new GoogleUser();
  }

}
