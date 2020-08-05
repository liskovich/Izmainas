import {Component} from "@angular/core";

@Component({
  selector: 'app-record-card',
  templateUrl: 'record-card.component.html',
  styleUrls: ['record-card.component.css']
})
export class RecordCardComponent {
  Property: any = {
    "Id": 1,
    "Type": "House",
    "Name": "Private house",
    "Price": 12000
  }
}
