import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-camera',
  templateUrl: './camera.component.html',
  styleUrls: ['./camera.component.css']
})
export class CameraComponent implements OnInit {
  constructor() { }

  @ViewChild('videoElement') videoElement: any;
  video: any;

  ngOnInit() {
    this.video = this.videoElement.nativeElement;
    this.initCamera({ video: true, audio: false });
  }
      

  initCamera(config: any) {
    var browser = <any>navigator;

    browser.getUserMedia = (browser.getUserMedia ||
      browser.webkitGetUserMedia ||
      browser.mozGetUserMedia ||
      browser.msGetUserMedia);

    browser.mediaDevices.getUserMedia(config).then(stream => {
      this.video.src = window.URL.createObjectURL(stream);
      this.video.play();
    });
  }        
}
