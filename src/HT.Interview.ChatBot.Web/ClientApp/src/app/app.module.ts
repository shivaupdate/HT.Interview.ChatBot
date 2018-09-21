import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';
import { RtcMediaRecorderModule } from './components/rtc-media-recorder/rtc-media-recorder.module';

import { ChatModule } from './modules/chat.module';          
import { SpeechModule } from './modules/speech.module';
import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { GoogleLoginProvider, FacebookLoginProvider } from "angularx-social-login";

import { HeaderComponent } from './components/header/header.component';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';        
import { HomePageComponent } from './components/home-page/home-page.component';
import { NavigationComponent } from './components/navigation-component/navigation.component';
import { ChatDialogComponent } from './components/chat-dialog/chat-dialog.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AdminComponent } from './components/admin/admin.component';
import { SocialUserProfileComponent } from './components/social-user-profile/social-user-profile.component';
import { CameraComponent } from './components/camera/camera.component';

import { DataService } from './services/data.service';
import { UserService } from './services/socialuser.service';
import { SearchPipe } from './models/search.pipe';
import { ChatService } from './services/chat.service';
import { SpeechService } from './services/speech.service';

let config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('754812502397-7vfce9jdlducrkk14ggr3mrbn050uoqg.apps.googleusercontent.com')
  },
  {
    id: FacebookLoginProvider.PROVIDER_ID,
    provider: new FacebookLoginProvider('339324976811993')    
  }
]);

const appRoutes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: '', component: HomePageComponent },
  { path: 'agent', component: ChatDialogComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'admin', component: AdminComponent },
  { path: 'socialprofile', component: SocialUserProfileComponent }

];

@NgModule({
  declarations: [
    HeaderComponent,
    AppComponent,
    FooterComponent,
    HomePageComponent,
    ChatDialogComponent,
    NavigationComponent,
    DashboardComponent,
    AdminComponent,
    SocialUserProfileComponent,
    SearchPipe,
    CameraComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ChatModule,       
    SpeechModule,
    SocialLoginModule.initialize(config), RtcMediaRecorderModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true})     
  ],
  providers: [DataService, UserService, ChatService, SpeechService, { provide: 'SPEECH_LANG', useValue: 'en-GB' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
