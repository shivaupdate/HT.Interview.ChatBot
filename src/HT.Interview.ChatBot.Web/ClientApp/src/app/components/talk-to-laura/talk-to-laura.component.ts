import { Component, OnInit, ViewChild, Input, Output, EventEmitter, AfterViewChecked, ElementRef } from '@angular/core';
import { Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { DOCUMENT } from '@angular/platform-browser';
import { Message } from '../../models/message';
import { ChatService } from '../../services/chat.service';
import { SpeechService } from '../../services/speech.service';
import { Constants } from '../../models/constants';
import { InterviewState } from '../../models/enums';
import { environment } from '../../../environments/environment';

import 'rxjs/add/operator/scan';
import 'rxjs/add/observable/timer';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/take';

@Component({
  selector: 'app-talk-to-laura',
  templateUrl: './talk-to-laura.component.html',
  styleUrls: ['./talk-to-laura.component.css']
})

export class TalkToLauraComponent implements OnInit, AfterViewChecked {
  @ViewChild('divChatWindow') public divChatWindow: ElementRef;
  @ViewChild('videoElement') videoElement: any;

  @Input() constrains = { video: true, audio: true };
  @Input() showVideoPlayer = true;
  @Input() showControls = false;

  @Output() startRecording = new EventEmitter();
  @Output() fetchRecording = new EventEmitter();

  private started = false;
  private sessionId: any;
  private message = new Message();
  private messages: Observable<Message[]>;
  private query: string;
  private countDown;
  private timerDelay = 0;
  private tick = 1000;
  private countdownTimer: any;
  private allocatedTime = 0;
  private remainingTime = 0;
  private constants = new Constants();
  private loggedInUser = JSON.parse(sessionStorage.getItem(this.constants.applicationUser));    
  private userName = this.loggedInUser.firstName;
  private photoUrl = this.loggedInUser.photoUrl;
  private interviewState: InterviewState;
  private formData: FormData = new FormData();
  private format = 'video/webm';
  private navigator = <any>navigator;
  private localStream;
  private video;
  private mediaRecorder;
  private recordedBlobs = null;              
  private webAPIUploadRecordingUrl = environment.application.webAPIUrl + environment.controller.interviewController + '/upload-video';

  ngOnInit() {
    this.interviewState = InterviewState.ShowInstruction;

    this.navigator.getUserMedia = (this.navigator.getUserMedia
      || this.navigator.webkitGetUserMedia
      || this.navigator.mozGetUserMedia
      || this.navigator.msGetUserMedia);     
  }

  ngAfterViewChecked() {
    this.resetControls();
  }

  constructor(@Inject(DOCUMENT) private document: Document, private router: Router, private http: HttpClient,
    public chat: ChatService, public speech: SpeechService) {

  }

  startInterview() {
    this.video = this.videoElement.nativeElement;
    this.startInterviewRecording();
    this.document.body.scrollTop = 0;
    console.log(this.document.body.scrollTop);
    this.interviewState = InterviewState.ConversationStarted;
    var __this = this;

    this.speech.started.subscribe(started => this.started = started);
    this.chat.defaultIntent(this.message);
    this.messages = this.chat.conversation.asObservable().scan((a, val) => a.concat(val));

    this.chat.conversation.subscribe(res => {
      this.remainingTime = 0;
      this.allocatedTime = 0;
      res.forEach(function (value) {
        if (value.response.result.metadata.endConversation) {
          __this.started = false;
          __this.message = new Message();
          __this.messages = new Observable<Message[]>();
          __this.interviewState = InterviewState.EndConversation;
          __this.stopInterviewRecording();
          __this.started = false;
          __this.speech.destroySpeechObject();
          __this.router.navigate(["/end-interview"]);
        }
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
  }

  toggleVoiceRecognition() {
    if (this.started) {
      this.started = true;
      this.speech.record()
        .subscribe(
          // listener
          (value) => {
            this.message.query = value;
            if (this.countdownTimer) {
              this.message.remainingTime = '';
              this.countdownTimer.unsubscribe();
            }
            this.message.timeTaken = String(this.allocatedTime - this.remainingTime);
            this.chat.converse(this.message);      
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
  }

  autoSendMessage(query: string) {
    this.query = query;
    this.sendMessage();
  }

  resetControls() {
    if (this.divChatWindow != undefined) {
      this.divChatWindow.nativeElement.scrollTop += 80;
    }
  }

  onScroll() {
  }

  private initStream(constrains, navigator) {
    return navigator.mediaDevices.getUserMedia(constrains)
      .then((stream) => {
        this.localStream = stream;
        return window.URL ? window.URL.createObjectURL(stream) : stream;
      })
      .catch(err => err);
  }

  public startInterviewRecording() {
    this.recordedBlobs = [];
    this.initStream(this.constrains, this.navigator)
      .then((stream) => {
        if (!window['MediaRecorder'].isTypeSupported(this.format)) {
          return;
        }
        try {
          this.mediaRecorder = new window['MediaRecorder'](this.localStream, { mimeType: this.format });
          if (this.video) {
            this.video.src = stream;
          }
          this.startRecording.emit(stream);
        } catch (e) {
          console.error('Exception while creating MediaRecorder: ' + e);
          return;
        }
        this.mediaRecorder.ondataavailable =
          (event) => {
            if (event.data && event.data.size > 0) {
              this.recordedBlobs.push(event.data);
            }
          };
        this.mediaRecorder.start(10);
      });
  }

  stopInterviewRecording() {
    const tracks = this.localStream.getTracks();
    tracks.forEach((track) => {
      track.stop();
    });

    this.mediaRecorder.stop();
    this.fetchRecording.emit(this.recordedBlobs);

    const blob = new Blob(this.recordedBlobs, { type: this.format });
    
    var fileName = this.loggedInUser.firstName + '.webm';      
    this.formData.append('id', this.loggedInUser.id);
    this.formData.append('firstName', this.loggedInUser.firstName);
    this.formData.append('lastName', this.loggedInUser.lastName);
    this.formData.append('recordingFile', blob, fileName);
    this.formData.append('modifiedBy', this.loggedInUser.email);
    this.http.post(this.webAPIUploadRecordingUrl, this.formData).subscribe(data => { });
  }
}
