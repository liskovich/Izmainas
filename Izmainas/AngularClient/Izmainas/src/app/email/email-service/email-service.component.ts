import { Component, OnInit } from '@angular/core';
import { EmailService } from 'src/app/services/email.service';
//import { IEmail } from '../IEmail.interface';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-email-service',
  templateUrl: './email-service.component.html',
  styleUrls: ['./email-service.component.css']
})
export class EmailServiceComponent implements OnInit {

  emailForm: FormGroup;
  emailDeleteForm: FormGroup;

  constructor(private emailService: EmailService) { }

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

    this.emailService.createNewEmail(this.getCreateEmailAddress()).subscribe();
    //this.emailForm.get('emailAddress').setValue(null);
  }

  onDeleteSubmit() {
    console.log(this.emailDeleteForm);

    this.emailService.deleteEmail(this.getDeleteEmailAddress()).subscribe();
    //this.emailDeleteForm.get('emailDeleteAddress').setValue(null);
  }
}
