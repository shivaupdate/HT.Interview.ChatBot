import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Message } from '../../models/message';
import { ChatService } from '../../services/chat.service';
import { SpeechService } from '../../services/speech.service';
import { Observable } from 'rxjs/Observable';
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
  message = new Message();
  messages: Observable<Message[]>;
  query: string;
  countDown;
  tick = 1000;

  constructor(public chat: ChatService, public speech: SpeechService) {
    this.speech.started.subscribe(started => this.started = started);
    this.chat.defaultIntent();
    this.messages = this.chat.conversation.asObservable().scan((a, val) => a.concat(val));
    var __this = this;

    this.chat.conversation.subscribe(res => {
      res.forEach(function (value) {
        value.response.result.fulfillment.messages.forEach(function (response) {
          // if response type is payload which holds the allocated time value
          if (response.type == 4) {
            var allocatedTime = Number(response.payload.allocatedTime);
            __this.message.allocatedTime = Observable.timer(0, __this.tick)
              .take(allocatedTime)
              .map(() => --allocatedTime);
          }
        });
      });
    });
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
      return 'fas fa-microphone-alt fa-2x';
    } else {
      return 'fa fa-microphone fa-2x';
    }
  }

  sendMessage() {
    this.message.query = this.query;
    this.chat.converse(this.message);
    this.query = '';
    this.resetControls();
  }

  autoSendMessage(query: string) {
    this.query = query;
    this.sendMessage();
  }

  resetControls() {
    this.divChatWindow.nativeElement.scrollTop = this.divChatWindow.nativeElement.scrollHeight - 300;
    this.message = new Message();
  }
}
