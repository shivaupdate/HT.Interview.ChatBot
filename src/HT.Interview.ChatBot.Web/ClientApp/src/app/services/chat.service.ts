import { Inject, Injectable } from '@angular/core';      
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Message } from '../models/message';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class ChatService {                                     
  conversation = new BehaviorSubject<Message[]>([]);
  constructor(private http: HttpClient, @Inject('SPEECH_LANG') public lang: string) { }

  //// Sends and receives messages via DialogFlow
  converse(userMessage: Message) {
    this.cancelSpeechSynthesis();
    if (userMessage.query === "C#") {
      userMessage.query = "Csharp";
    }                                              
    this.getApiAiResponse(userMessage.query).subscribe(
      response => {
        this.updateConversation(response);
      }
    );
  }

  defaultIntent() {
    this.cancelSpeechSynthesis();
    this.getApiAiResponse("Hello").subscribe(
      response => {
        response.result.resolvedQuery = '';
        this.updateConversation(response);
      });
  }

  updateConversation(response: any) {
    const message = new Message();
    message.timestamp = new Date();
    message.response = response;
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

  getApiAiResponse(query): Observable<any> {
    var url = "http://localhost:50463/api/v1/interview/get?text=" + query;
    
    return this.http.get(url, { responseType: 'json' });
  }
}
