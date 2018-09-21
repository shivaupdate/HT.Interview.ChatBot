import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';
import { RtcMediaRecorderModule } from './components/rtc-media-recorder/rtc-media-recorder.module';

import { NavbarModule, WavesModule, ButtonsModule } from 'angular-bootstrap-md'
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { ChatModule } from './modules/chat.module';          
import { SpeechModule } from './modules/speech.module';
import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { GoogleLoginProvider, FacebookLoginProvider } from "angularx-social-login";

import { AuthGuard } from './_guards';
import { LoginComponent } from './components/login/login.component';
import { StandardComponent } from './components/standard/standard.component';
import { HeaderComponent } from './components/header/header.component';
import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';        
import { HomeComponent } from './components/home/home.component';
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
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },   
  { path: 'agent', component: ChatDialogComponent, canActivate: [AuthGuard]},
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard]},
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard]},
  { path: 'socialprofile', component: SocialUserProfileComponent, canActivate: [AuthGuard]}

];

@NgModule({
  declarations: [
    LoginComponent,
    StandardComponent,
    HeaderComponent,
    AppComponent,
    FooterComponent,
    HomeComponent,
    ChatDialogComponent,
    NavigationComponent,
    DashboardComponent,
    AdminComponent,
    SocialUserProfileComponent,
    SearchPipe,
    CameraComponent
  ],
  imports: [
    MDBBootstrapModule.forRoot(),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NavbarModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    ChatModule,       
    SpeechModule,
    SocialLoginModule.initialize(config), RtcMediaRecorderModule,
    RouterModule.forRoot(appRoutes, { enableTracing: false})     
  ],
  schemas: [NO_ERRORS_SCHEMA],
  providers: [AuthGuard, DataService, UserService, ChatService, SpeechService, { provide: 'SPEECH_LANG', useValue: 'en-GB' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
