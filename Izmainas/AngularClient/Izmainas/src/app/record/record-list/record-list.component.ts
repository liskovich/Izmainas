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
  presentDate: string;

  constructor(private recordService: RecordServiceService) { }

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
    var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();

    const dateOptions = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    var rawDate = today.toLocaleDateString('lv-LV', dateOptions);
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

    /*
    this.recordService.getToday().subscribe(
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
  }

}
