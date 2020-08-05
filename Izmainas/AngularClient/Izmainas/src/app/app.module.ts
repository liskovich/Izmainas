import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

//import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecordCardComponent } from './record/record-card/record-card.component';
import { RecordListComponent } from './record/record-list/record-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';

@NgModule({
   declarations: [
      AppComponent,
      RecordCardComponent,
      RecordListComponent,
      NavBarComponent
   ],
   imports: [
      BrowserModule,
      //AppRoutingModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
