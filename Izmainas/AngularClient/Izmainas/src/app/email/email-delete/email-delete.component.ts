import { Component, OnInit } from '@angular/core';
import { EmailService } from 'src/app/services/email.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-email-delete',
  templateUrl: './email-delete.component.html',
  styleUrls: ['./email-delete.component.css']
})
export class EmailDeleteComponent implements OnInit {

  email: string;
  //cdate: string;

  public hidden: boolean;

  constructor(private emailService: EmailService, private route: ActivatedRoute) { }

  ngOnInit() {
    if(this.route.snapshot.queryParamMap.has('email') && this.route.snapshot.queryParamMap.has('cdate')){ // && this.route.snapshot.queryParamMap.has('cdate')
      this.email = this.route.snapshot.queryParamMap.get('email');
      //this.cdate = this.route.snapshot.queryParamMap.get('cdate');

      //console.log(this.email);
      try{
        var result = this.delete(this.email);
        //console.log(result);
        //this.hidden = false;
      } catch {
        //this.hidden = true;
      }
    }
    else{
      console.log('not enough parameters');
      this.hidden = true;
    }
  }

  private delete(emailText: string){
    this.emailService.deleteEmail(emailText).subscribe(
      (res) => {
        if(res.status === 204){
          this.hidden = false;
        }
      },
      (error) => {
        if(error.status === 404){
          this.hidden = true;
        }else{
          this.hidden = true;
        }
      }
    );
  }
}
