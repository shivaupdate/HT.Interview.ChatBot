import { Injectable } from '@angular/core';

@Injectable()
export class DataService {

  public message : string;
  constructor() { }

  setMessage(data: string) : void
  {
    this.message = data;
  }

  getMessage() : string
  {
    return this.message;
  }

}
