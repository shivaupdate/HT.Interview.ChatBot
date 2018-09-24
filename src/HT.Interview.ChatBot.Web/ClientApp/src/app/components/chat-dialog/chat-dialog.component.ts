import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Message } from '../../models/message';
import { ChatService } from '../../services/chat.service';
import { SpeechService } from '../../services/speech.service';
import { Observable } from 'rxjs/Observable';
import { Constants } from '../../models/constants';

import 'rxjs/add/operator/scan';
import 'rxjs/add/observable/timer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/take';

@Component({
  selector: 'chat-dialog',
  templateUrl: './chat-dialog.component.html',
  styleUrls: ['./chat-dialog.component.css']
})

export class ChatDialogComponent {
  @ViewChild('divChatWindow', { read: ElementRef }) public divChatWindow;
  started = false;       
  sessionId: any;
  message = new Message();
  messages: Observable<Message[]>;
  query: string;
  countDown;
  timerDelay = 0;
  tick = 1000;
  countdownTimer: any;
  allocatedTime = 0;
  remainingTime = 0;         
  private constants = new Constants();  
  private user = JSON.parse(localStorage.getItem(this.constants.applicationUser));
  private userName = this.user.firstName;
  private photoUrl = this.user.photoUrl;     

  constructor(public chat: ChatService, public speech: SpeechService) {
    var __this = this;
                                     
    this.speech.started.subscribe(started => this.started = started);
    this.chat.defaultIntent(this.message);
    this.messages = this.chat.conversation.asObservable().scan((a, val) => a.concat(val));

    this.chat.conversation.subscribe(res => {
      res.forEach(function (value) {
        value.response.result.fulfillment.messages.forEach(function (response) {

          // if response type is payload which holds the allocated time value     
          if (response.type == 4) {
            var minutes;
            var seconds;
            __this.allocatedTime = Number(response.payload.allocatedTime);
            __this.remainingTime = __this.allocatedTime;
            if (__this.countdownTimer) {
              __this.message.remainingTime = '';
              __this.countdownTimer.unsubscribe();
            }

            if (__this.remainingTime > 0) {

              __this.countdownTimer = Observable.timer(__this.timerDelay, __this.tick).subscribe(x => {
                minutes = Math.floor((__this.remainingTime % 3600) / 60);
                seconds = Math.floor(__this.remainingTime % 60);

                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;

                __this.message.remainingTime = 'Time Remaining: ' + String(minutes) + ":" + String(seconds);
                __this.remainingTime = __this.remainingTime - 1;

                if (__this.remainingTime < 0) {
                  __this.noReponseFromCandidate();
                }
              })
            };
          }
        });
      })
    });
  }

  noReponseFromCandidate() {
    this.remainingTime = 0;
    this.allocatedTime = 0;
    this.timerDelay = 5;
    this.message.timeTaken = '';
    this.message.query = 'Allocated time expired';
    this.chat.moveToNextIntent(this.message);
    this.resetControls();
  }

  toggleVoiceRecognition() {
    if (!this.started) {
      this.started = true;
      this.speech.record()
        .subscribe(
          // listener
          (value) => {
            this.message.query = value;
            this.chat.converse(this.message);
            this.resetControls();
          },
          // errror
          (err) => {
            if (err.error === 'no-speech') {
              this.started = false;
              this.toggleVoiceRecognition();
              // TODO: Show error message
            }
          });
    } else {
      this.started = false;
      this.speech.destroySpeechObject();
    }
  }

  getMicStyle() {
    if (this.started) {
      return 'fa fa-microphone-slash fa-2x';
    } else {
      return 'fa fa-microphone fa-2x';
    }
  }

  sendMessage() {
    this.message.query = this.query;
    this.message.timeTaken = String(this.allocatedTime - this.remainingTime);
    this.chat.converse(this.message);
    this.query = '';
    this.resetControls();
  }

  autoSendMessage(query: string) {
    this.query = query;
    this.sendMessage();
  }

  resetControls() {
    this.divChatWindow.nativeElement.scrollTop = this.divChatWindow.nativeElement.scrollTop + 200;
  }          
}
