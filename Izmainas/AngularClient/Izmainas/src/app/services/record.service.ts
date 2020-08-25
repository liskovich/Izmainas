import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { IRecord } from '../record/IRecord.interface';
import { Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RecordService {

  private controllerEndpoint = `client/records`;
  private dateEnpoint = `client/records/dates/`;

  private todayEndpoint = `client/records/today`;
  private tomorrowEndpoint = `client/records/tomorrow`;

  constructor(private http:HttpClient) { }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }

  // API endpoints
  getAllRecords() : Observable<IRecord[]> {
    return this.http.get(`${environment.endpoint}${this.controllerEndpoint}`)
    .pipe(
      map(data => {
        const recordsArray: Array<IRecord> = [];
        for(const id in data){
          if(data.hasOwnProperty(id))
          {
            recordsArray.push(data[id]);
          }
        }
        return recordsArray;
      }),
      catchError(this.handleError)
    );
  }

  getByDate(date: string) : Observable<IRecord[]> {
    return this.http.get(`${environment.endpoint}${this.dateEnpoint}${date}`)
    .pipe(
      map(data => {
        const recordsArray: Array<IRecord> = [];
        for(const id in data){
          if(data.hasOwnProperty(id)){
            recordsArray.push(data[id]);
          }
        }
        return recordsArray;
      }),
      catchError(this.handleError)
    );
  }

  /*
  getToday() : Observable<IRecord[]> {
    return this.http.get(`${environment.endpoint}${this.todayEndpoint}`)
    .pipe(
      map(data => {
        const recordsArray: Array<IRecord> = [];
        for(const id in data){
          if(data.hasOwnProperty(id)){
            recordsArray.push(data[id]);
          }
        }
        return recordsArray;
      })
    );
  }

  getTomorrow() : Observable<IRecord[]> {
    return this.http.get(`${environment.endpoint}${this.tomorrowEndpoint}`)
    .pipe(
      map(data => {
        const recordsArray: Array<IRecord> = [];
        for(const id in data){
          if(data.hasOwnProperty(id)){
            recordsArray.push(data[id]);
          }
        }
        return recordsArray;
      })
    );
  }
  */
}
