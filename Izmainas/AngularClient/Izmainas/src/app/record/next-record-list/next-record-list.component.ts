import { Component, OnInit } from '@angular/core';
import { RecordService } from 'src/app/services/record.service';
import { IRecord } from '../IRecord.interface';

@Component({
  selector: 'app-next-record-list',
  templateUrl: './next-record-list.component.html',
  styleUrls: ['./next-record-list.component.css']
})
export class NextRecordListComponent implements OnInit {

  records: Array<IRecord>;
  presentDate: string;

  constructor(private recordService: RecordService) { }

  ngOnInit(): void {
    /*
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
    */

    function capitalizeFirstLetter(string) {
      return string.charAt(0).toUpperCase() + string.slice(1);
    }

    var today = new Date();
    var tomorrow = new Date(today);
    tomorrow.setDate(tomorrow.getDate()+1);

    var date = tomorrow.getFullYear()+'-'+(tomorrow.getMonth()+1)+'-'+(tomorrow.getDate());
    var rawPresentDate = new Date(date);

    const dateOptions = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    var rawDate = rawPresentDate.toLocaleDateString('lv-LV', dateOptions);
    this.presentDate = capitalizeFirstLetter(rawDate);

    this.recordService.getByDate(date).subscribe(
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
