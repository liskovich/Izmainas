/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RecordService } from './record.service';

describe('Service: RecordService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecordService]
    });
  });

  it('should ...', inject([RecordService], (service: RecordService) => {
    expect(service).toBeTruthy();
  }));
});
