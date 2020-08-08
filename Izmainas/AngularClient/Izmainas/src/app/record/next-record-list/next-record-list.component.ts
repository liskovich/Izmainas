import { Component, OnInit } from '@angular/core';
import { RecordServiceService } from 'src/app/services/recordService.service';
import { IRecord } from '../IRecord.interface';

@Component({
  selector: 'app-next-record-list',
  templateUrl: './next-record-list.component.html',
  styleUrls: ['./next-record-list.component.css']
})
export class NextRecordListComponent implements OnInit {

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
