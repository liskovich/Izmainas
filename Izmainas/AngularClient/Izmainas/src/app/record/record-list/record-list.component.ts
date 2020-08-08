import { Component, OnInit } from '@angular/core';
import { RecordServiceService } from 'src/app/services/recordService.service';
import { IRecord } from '../IRecord.interface';

@Component({
  selector: 'app-record-list',
  templateUrl: './record-list.component.html',
  styleUrls: ['./record-list.component.css']
})
export class RecordListComponent implements OnInit {

  records: Array<IRecord>;

  constructor(private recordService: RecordServiceService) { }

  ngOnInit(): void {
    this.recordService.getAllRecords().subscribe(
      data => {
        this.records = data;
        console.log(data);
      },
      error => {
        console.log('httperror:');
        console.log(error);
      }
    )
  }

}
