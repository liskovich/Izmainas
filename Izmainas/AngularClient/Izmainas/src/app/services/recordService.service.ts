import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { IRecord } from '../record/IRecord.interface';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RecordServiceService {

  private controllerEndpoint = `records`;
  private dateEnpoint = `records/dates/`;
  private todayEndpoint = `records/today`;
  private tomorrowEndpoint = `records/tomorrow`;

  constructor(private http:HttpClient) { }

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
      })
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
      })
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
