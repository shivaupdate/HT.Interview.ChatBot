import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

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
    RouterModule.forRoot([
      { path: '', component: ChatDialogComponent, pathMatch: 'full' } 
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
