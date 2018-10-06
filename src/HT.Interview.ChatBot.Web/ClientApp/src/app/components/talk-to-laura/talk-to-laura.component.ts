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
  private webAPIUrl = environment.application.webAPIUrl + environment.controller.interviewController + '/upload-video';
  private interviewState: InterviewState;
  private formData: FormData = new FormData();

  @Input() constrains = { video: true, audio: false };
  @Input() fileName = 'my_recording';
  @Input() showVideoPlayer = true;
  @Input() showControls = false;

  @Output() startRecording = new EventEmitter();
  @Output() downloadRecording = new EventEmitter();
  @Output() fetchRecording = new EventEmitter();

  format = 'video/webm';
  _navigator = <any>navigator;
  localStream;
  video;
  mediaRecorder;
  recordedBlobs = null;
  hideStopBtn = true;

  ngOnInit() {
    this.interviewState = InterviewState.ShowInstruction;

    this._navigator.getUserMedia = (this._navigator.getUserMedia
      || this._navigator.webkitGetUserMedia
      || this._navigator.mozGetUserMedia
      || this._navigator.msGetUserMedia);

  }

  ngAfterViewChecked() {
    this.resetControls();
  }

  constructor(@Inject(DOCUMENT) private document: Document, private router: Router, private http: HttpClient, public chat: ChatService, public speech: SpeechService) {
    
  }

  startInterview() {
    this.video = this.videoElement.nativeElement;

    this.start();
    this.document.body.scrollTop = 0;
    console.log(this.document.body.scrollTop);
    this.interviewState = InterviewState.ConversationStarted;
    var __this = this;

    this.speech.started.subscribe(started => this.started = started);
    this.chat.defaultIntent(this.message);
    this.messages = this.chat.conversation.asObservable().scan((a, val) => a.concat(val));

    this.chat.conversation.subscribe(res => {
      res.forEach(function (value) {
        if (value.response.result.metadata.endConversation) {
          __this.started = false;
          __this.message = new Message();
          __this.messages = new Observable<Message[]>();
          __this.interviewState = InterviewState.EndConversation;
          __this.router.navigate(["/end-interview"]);
          // __this.handleVideoStream();
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
    //this.resetControls();
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
    // this.resetControls();
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

  stopRecording() {

  }

  private initStream(constrains, navigator) {
    return navigator.mediaDevices.getUserMedia(constrains)
      .then((stream) => {
        this.localStream = stream;
        return window.URL ? window.URL.createObjectURL(stream) : stream;
      })
      .catch(err => err);
  }
  private stopStream() {
    const tracks = this.localStream.getTracks();
    tracks.forEach((track) => {
      track.stop();
    });
  }

  public start() {
    console.log('start recording');
    this.recordedBlobs = [];
    this.initStream(this.constrains, this._navigator)
      .then((stream) => {
        if (!window['MediaRecorder'].isTypeSupported(this.format)) {
          console.log(this.format + ' is not Supported');
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
        console.log('Created MediaRecorder', this.mediaRecorder, 'with options', this.format);
        this.hideStopBtn = false;
        this.mediaRecorder.ondataavailable =
          (event) => {
            if (event.data && event.data.size > 0) {
              this.recordedBlobs.push(event.data);
            }
          };
        this.mediaRecorder.start(10); // collect 10ms of data
      });
  }

  public stop() {
    console.log('stop recording');
    this.hideStopBtn = true;

    this.stopStream();
    this.mediaRecorder.stop();
    this.fetchRecording.emit(this.recordedBlobs);
    if (this.video) {
      this.video.controls = true;
    }
    this.download();
  }

  handleVideoStream(blob) {
    // can send it to a server or play in another video player etc..
    console.log('do something with the recording' + blob);
  }

  public download() {
    console.log('download recorded stream');
    const timestamp = new Date().getUTCMilliseconds();
    const blob = new Blob(this.recordedBlobs, { type: this.format });
    var formData = new FormData();
    var fileName = 'ABCDEF.webm';
    formData.append('firstName', "test");
    formData.append('lastName', "test");
    formData.append('email', "test");
    formData.append('mobile', "test");
    formData.append('recordingFile', blob, fileName);
    this.http.post(this.webAPIUrl, formData).subscribe(data => { });



    const url = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.style.display = 'none';
    a.href = url;
    a.download = timestamp + '__' + this.fileName + '.webm';
    document.body.appendChild(a);
    console.log(blob);
    //a.click();
    setTimeout(() => {
      document.body.removeChild(a);
      window.URL.revokeObjectURL(url);
      this.downloadRecording.emit();
    }, 100);
  }

}
