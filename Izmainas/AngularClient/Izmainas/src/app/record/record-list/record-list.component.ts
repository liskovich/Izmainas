import { Component, OnInit } from '@angular/core';
import { RecordService } from 'src/app/services/record.service';
import { IRecord } from '../IRecord.interface';

@Component({
  selector: 'app-record-list',
  templateUrl: './record-list.component.html',
  styleUrls: ['./record-list.component.css']
})

export class RecordListComponent implements OnInit {

  records: Array<IRecord>;
  presentDate: string;
  hidden: boolean;

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
    var date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();

    const dateOptions = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    var rawDate = today.toLocaleDateString('lv-LV', dateOptions);
    this.presentDate = capitalizeFirstLetter(rawDate);

    this.recordService.getByDate(date).subscribe(
      data => {
        this.records = data;
        console.log(data);
        if(this.records.length == 0 || this.records === undefined){
          this.hidden = true;
        }else{
          this.hidden = false;
        }
      },
      error => {
        console.log('httperror:');
        console.log(error);
        this.hidden = true;
      }
    )

    /*
    if(this.records == null){
      this.hidden = true;
    }*/

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
