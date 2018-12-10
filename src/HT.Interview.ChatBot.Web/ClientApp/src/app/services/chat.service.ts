import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Message } from '../models/message';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { Constants } from '../models/constants';
import { environment } from '../../environments/environment';

@Injectable()
export class ChatService {
  private constants = new Constants();
  private loggedInUser = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));
  private userId = this.loggedInUser.id;
  private sessionId = this.loggedInUser.sessionId;
  private email = this.loggedInUser.email;

  private interviewId: number;
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.interviewController + environment.action.getWithParameters;
  conversation = new BehaviorSubject<Message[]>([]);

  constructor(private http: HttpClient, @Inject('SPEECH_LANG') public lang: string) { }

  //// Sends and receives messages via DialogFlow
  converse(message: Message) {
    this.cancelSpeechSynthesis();
    if (message.query === "C#") {
      message.query = "Csharp";
    }
    this.getApiAiResponse(message).subscribe(
      response => {
        this.updateConversation(response);
      }
    );
  }

  //// Sends and receives messages via DialogFlow
  moveToNextIntent(message: Message) {
    this.cancelSpeechSynthesis();
    this.getApiAiResponse(message).subscribe(
      response => {
        response.result.resolvedQuery = message.query;
        this.updateConversation(response);
      }
    );
  }

  defaultIntent(message: Message) {
    this.cancelSpeechSynthesis();
    //message.query = this.loggedInUser.firstName;
    message.query = "Hello";
    message.firstRequest = true;
    this.getApiAiResponse(message).subscribe(
      response => {
        response.result.resolvedQuery = '';
        this.updateConversation(response);
      });
    message.firstRequest = false;
  }

  updateConversation(response: any) {
    const message = new Message();
    message.timestamp = new Date();
    message.response = response;
    this.interviewId = response.result.interviewId;
    this.conversation.next([message]);
    this.speak(response.result.fulfillment.speech);
  }

  cancelSpeechSynthesis() {
    if (speechSynthesis.speaking) {
      speechSynthesis.cancel();
    }
  }

  speak(text) {
    var voices = speechSynthesis.getVoices();
    var botVoice = new SpeechSynthesisUtterance();
    botVoice.voice = voices[1]; //Google UK English Female
    botVoice.text = text;
    botVoice.lang = this.lang;
    botVoice.rate = 1.2; //Speech rate 
    speechSynthesis.speak(botVoice);
  }

  getApiAiResponse(message: Message): Observable<any> {      

    let params = new HttpParams();
    params = params.append('userId', this.userId);
    params = params.append('sessionId', this.sessionId);
    params = params.append('interviewId', String(this.interviewId));
    params = params.append('query', message.query);
    params = params.append('timeTaken', message.timeTaken);
    params = params.append('firstRequest', String(message.firstRequest));
    params = params.append('email', this.email);

    return this.http.get(this.webAPIUrl, { params });
  }
}
