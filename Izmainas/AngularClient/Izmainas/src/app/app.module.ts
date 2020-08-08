import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecordCardComponent } from './record/record-card/record-card.component';
import { RecordListComponent } from './record/record-list/record-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RecordServiceService } from './services/recordService.service';
import { NextRecordListComponent } from './record/next-record-list/next-record-list.component';

const appRoutes: Routes = [
  { path: '', component: RecordListComponent },
  { path: 'next-record-list', component: NextRecordListComponent }
]

@NgModule({
   declarations: [
      AppComponent,
      RecordCardComponent,
      RecordListComponent,
      NavBarComponent,
      NextRecordListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes)
      //AppRoutingModule
   ],
   providers: [
     RecordServiceService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
