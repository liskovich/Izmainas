import { Component, OnInit, Inject } from '@angular/core';
import { EmailService } from 'src/app/services/email.service';
//import { IEmail } from '../IEmail.interface';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MessageDialogComponent } from 'src/app/dialog/message-dialog/message-dialog.component';

@Component({
  selector: 'app-email-service',
  templateUrl: './email-service.component.html',
  styleUrls: ['./email-service.component.css']
})
export class EmailServiceComponent implements OnInit {

  emailForm: FormGroup;
  emailDeleteForm: FormGroup;

  constructor(private emailService: EmailService, private dialog: MatDialog) { }

  ngOnInit() {

    this.emailForm = new FormGroup({
      emailAddress: new FormControl(null, [Validators.required, Validators.email])
    });

    this.emailDeleteForm = new FormGroup({
      emailDeleteAddress: new FormControl(null, [Validators.required, Validators.email])
    });

    //this.emailService.createNewEmail("test@test.com").subscribe();

    //this.emailService.deleteEmail("test@test.com").subscribe();
  }

  getCreateEmailAddress(): string {
    return this.emailForm.get('emailAddress').value as string;
  }

  getDeleteEmailAddress(): string {
    return this.emailDeleteForm.get('emailDeleteAddress').value as string;
  }

  onSubmit() {
    console.log(this.emailForm);

    this.emailService.createNewEmail(this.getCreateEmailAddress())
    .subscribe(
      /*
      (error) => {
        console.log(error.status);
      }*/
      (res) => {
        //console.log(res.status);
        if(res.status === 201){
          //console.log(res);
          this.openDialog("Reģistrācija veiksmīga", "Uz norādīto e-pasta adresi tiks nosūtīta verifikācijas saite, kura būs aktīva 1 stundu");
        }
      },
      (error) => { //error: error
        //console.error(error.status);
        var response = error.status;
        //console.log(response);

        if(response === 400){
          //let dialogRef = dialog
          this.openDialog("Kļūda", "Šis e-pasts jau ir aizņemts");
        }else{
          this.openDialog("Kļūda", "Tehnisku iemeslu dēļ nav iespējams pieteikties ziņojumiem");
        }
      }
    );

    this.emailForm.reset();
    // TODO - solve the issue with incorrect dialog showing

    //this.openDialog("Reģistrācija veiksmīga", "Uz norādīto e-pasta adresi tiks nosūtīta verifikācijas saite, kura būs aktīva 1 stundu");

    /*.subscribe(
      (error) => {
        //console.log(error);
        //console.log(error.status);
        console.log("lololololol");

        if(error.status === 400){
          console.log("dachi");
        }
        console.log(error.status);
      }
    )*/

    /*
    .subscribe(
      response => {
        const keys = response.headers.keys
        console.log(response);
      }
    );
    */
    //this.emailForm.get('emailAddress').setValue(null);
  }

  onDeleteSubmit() {
    console.log(this.emailDeleteForm);

    //this.emailService.deleteEmail(this.getDeleteEmailAddress()).subscribe();


    //this.emailDeleteForm.get('emailDeleteAddress').setValue(null);
  }

  private openDialog(msgTitle: string, msgBody: string): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = {
      title: msgTitle,
      body: msgBody
    };
    this.dialog.open(MessageDialogComponent, dialogConfig);
  }
}
