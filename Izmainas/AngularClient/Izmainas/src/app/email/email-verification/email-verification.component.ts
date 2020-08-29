import { Component, OnInit } from '@angular/core';
import { EmailService } from 'src/app/services/email.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-email-verification',
  templateUrl: './email-verification.component.html',
  styleUrls: ['./email-verification.component.css']
})
export class EmailVerificationComponent implements OnInit {

  email: string;
  vkey: string;

  public hidden: boolean;

  constructor(private emailService: EmailService, private route: ActivatedRoute) {
    //this.hidden = true;
  }

  ngOnInit() {
    /*
    console.log(this.route.snapshot.queryParamMap.has('email'));
    console.log(this.route.snapshot.queryParamMap.get('email'));
    console.log(this.route.snapshot.queryParamMap.getAll('email'));

    console.log(this.route.snapshot.queryParamMap.has('vkey'));
    console.log(this.route.snapshot.queryParamMap.get('vkey'));
    console.log(this.route.snapshot.queryParamMap.getAll('vkey'));
    console.log(this.route.snapshot.queryParamMap.keys);
    */
    if(this.route.snapshot.queryParamMap.has('email') && this.route.snapshot.queryParamMap.has('vkey')){
      this.email = this.route.snapshot.queryParamMap.get('email');
      this.vkey = this.route.snapshot.queryParamMap.get('vkey');

      console.log(this.email, this.vkey);
      try {
        var result = this.verify(this.email, this.vkey);
        console.log(result);
        this.hidden = false;
      } catch {
        this.hidden = true;
      }
    }
    else{
      console.error('not enough parameters');
      this.hidden = true;
    }
  }

  private verify(emailText: string, verificationKey: string) {
    this.emailService.verifyEmail(emailText, verificationKey).subscribe();
  }
}
