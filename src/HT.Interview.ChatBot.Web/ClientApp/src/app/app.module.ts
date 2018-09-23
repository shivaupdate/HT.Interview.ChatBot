import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';

import { NavbarModule } from 'angular-bootstrap-md'
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { AgGridModule } from 'ag-grid-angular';

import { ChatModule } from './modules/chat.module';
import { SpeechModule } from './modules/speech.module';
import { SocialLoginModule, AuthServiceConfig } from "angularx-social-login";
import { GoogleLoginProvider, FacebookLoginProvider } from "angularx-social-login";

import { AuthGuard } from './_guards';
import { LoginComponent } from './components/login/login.component';
import { AppComponent } from './app.component';
import { StandardComponent } from './components/standard/standard.component';

import { HeaderComponent } from './components/standard/header/header.component';
import { FooterComponent } from './components/standard/footer/footer.component';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { InterviewEvaluationComponent } from './components/interview-evaluation/interview-evaluation.component';
import { ManageUserComponent } from './components/manage-user/manage-user.component';
import { InterviewInstructionComponent } from './components/interview-instruction/interview-instruction.component';
import { ChatDialogComponent } from './components/chat-dialog/chat-dialog.component';
import { CameraComponent } from './components/camera/camera.component';

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
  { path: 'login', component: LoginComponent },
  { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'interview-evaluation', component: InterviewEvaluationComponent, canActivate: [AuthGuard] },
  { path: 'manage-users', component: ManageUserComponent, canActivate: [AuthGuard] },
  { path: 'interview-instruction', component: InterviewInstructionComponent, canActivate: [AuthGuard] },
  { path: 'talk-to-laura', component: ChatDialogComponent, canActivate: [AuthGuard] }
];

@NgModule({
  declarations: [
    LoginComponent,
    StandardComponent,
    HeaderComponent,
    FooterComponent,
    AppComponent,
    DashboardComponent,
    InterviewEvaluationComponent,
    ManageUserComponent,
    InterviewInstructionComponent,
    ChatDialogComponent,
    CameraComponent
  ],
  imports: [
    MDBBootstrapModule.forRoot(),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NavbarModule,
    AgGridModule.withComponents([]),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ChatModule,
    SpeechModule,
    SocialLoginModule.initialize(config),
    RouterModule.forRoot(appRoutes, { enableTracing: false })
  ],
  schemas: [NO_ERRORS_SCHEMA],
  providers: [AuthGuard, ChatService, SpeechService, { provide: 'SPEECH_LANG', useValue: 'en-GB' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
