import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { IEmail } from '../email/IEmail.interface';
import { IVerificationEmail } from '../email/IVerificationEmail.interface';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  private createEndpoint = `tempemailmodels`; //client/emailmodels
  private deleteEndpoint = `client/emailmodels/emails/`; //{email}
  private verifyEndpoint = `tempemailmodels/verify`;

  constructor(private http: HttpClient) { }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Failed to complete the operation.');
  }

  // API endpoints
  createNewEmail(emailText: string): Observable<{}> { //IEmail

    var em = new IEmail();
    em.email = emailText;
    em.createdDate = new Date();

    return this.http.post<IEmail>(`${environment.endpoint}${this.createEndpoint}`, em)
    .pipe(
      catchError(this.handleError) //'createNewEmail', email
    );
  }

  deleteEmail(emailText: string): Observable<{}> {
    return this.http.delete(`${environment.endpoint}${this.deleteEndpoint}${emailText}`)
    .pipe(
      catchError(this.handleError)
    )
  }

  verifyEmail(emailText: string, vkey: string): Observable<{}> {

    var vem = new IVerificationEmail();
    vem.email = emailText;
    vem.verificationKey = vkey;

    return this.http.post<IVerificationEmail>(`${environment.endpoint}${this.verifyEndpoint}`, vem)
    .pipe(
      catchError(this.handleError)
    );
  }
}
