import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Message } from '../models/message';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import { environment } from '../../environments/environment';     

@Injectable()
export class ChatService {
  conversation = new BehaviorSubject<Message[]>([]);   
  dialogflowGeneratedIntentId: string;
  constructor(private http: HttpClient, @Inject('SPEECH_LANG') public lang: string) { }          
  webAPIUrl = environment.application.webAPIUrl + environment.controller.interviewController + environment.action.getWithParameters;

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
    message.query = 'Hello';
    this.getApiAiResponse(message).subscribe(
      response => {
        response.result.resolvedQuery = '';
        this.updateConversation(response);
      });
  }

  updateConversation(response: any) {
    const message = new Message();
    message.timestamp = new Date();
    message.response = response;               
    this.dialogflowGeneratedIntentId = response.result.metadata.intentId;
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
    params = params.append('UserId', message.userId);
    params = params.append('SessionId', message.sessionId);  
    params = params.append('DialogflowGeneratedIntentId', this.dialogflowGeneratedIntentId);    
    params = params.append('Query', message.query);
    params = params.append('TimeTaken', message.timeTaken);
    
    return this.http.get(this.webAPIUrl, { params });
  }   
}
