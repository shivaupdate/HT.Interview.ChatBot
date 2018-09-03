import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ChatModule } from './modules/chat.module';
import { HelpSectionModule } from './modules/help-section.module';
import { SpeechModule } from './modules/speech.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { ChatDialogComponent } from './components/chat-dialog/chat-dialog.component';  

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ChatDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ChatModule,
    HelpSectionModule,
    SpeechModule,
    RouterModule.forRoot([
      { path: '', component: ChatDialogComponent, pathMatch: 'full' }
    ])
  ],
  providers: [{ provide: 'SPEECH_LANG', useValue: 'en-GB' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
