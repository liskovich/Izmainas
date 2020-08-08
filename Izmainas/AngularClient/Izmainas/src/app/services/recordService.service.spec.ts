/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { RecordServiceService } from './recordService.service';

describe('Service: RecordService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RecordServiceService]
    });
  });

  it('should ...', inject([RecordServiceService], (service: RecordServiceService) => {
    expect(service).toBeTruthy();
  }));
});
