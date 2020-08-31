import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
//import { data } from 'jquery';

@Component({
  selector: 'app-message-dialog',
  templateUrl: './message-dialog.component.html',
  styleUrls: ['./message-dialog.component.css']
})
export class MessageDialogComponent implements OnInit {

  title: string;
  messageText: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private dialogRef: MatDialogRef<MessageDialogComponent>) {

   }

  ngOnInit() {
    console.log(this.data);
    this.title = this.data.title;
    this.messageText = this.data.body;

    //console.log(this.data.body);
    //console.log(this.data.body);

    //console.log(this.title);
    //console.log(this.messageText);

  }

  close() {
    this.dialogRef.close();
  }
}
