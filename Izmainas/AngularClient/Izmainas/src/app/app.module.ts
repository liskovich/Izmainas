import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';

//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecordCardComponent } from './record/record-card/record-card.component';
import { RecordListComponent } from './record/record-list/record-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RecordService } from './services/record.service';
import { EmailService } from './services/email.service';
import { NextRecordListComponent } from './record/next-record-list/next-record-list.component';
import { EmailServiceComponent } from './email/email-service/email-service.component';
import { EmailVerificationComponent } from './email/email-verification/email-verification.component';

const appRoutes: Routes = [
  { path: '', component: RecordListComponent },
  { path: 'rit', component: NextRecordListComponent }, //next-record-list
  { path: 'noderigi', component: EmailServiceComponent },
  { path: 'verification', component: EmailVerificationComponent }
]

@NgModule({
   declarations: [
      AppComponent,
      RecordCardComponent,
      RecordListComponent,
      NavBarComponent,
      NextRecordListComponent,
      EmailServiceComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes),
      CommonModule
      //AppRoutingModule
   ],
   providers: [
      RecordService,
      EmailService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
