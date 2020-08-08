import {Component, Input} from "@angular/core";
import { IRecord } from '../IRecord.interface';

@Component({
  selector: 'app-record-card',
  templateUrl: 'record-card.component.html',
  styleUrls: ['record-card.component.css']
})
export class RecordCardComponent {
  @Input() record : IRecord
}
