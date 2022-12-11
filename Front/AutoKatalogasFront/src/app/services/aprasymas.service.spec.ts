import { TestBed } from '@angular/core/testing';

import { AprasymasService } from './aprasymas.service';

describe('AprasymasService', () => {
  let service: AprasymasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AprasymasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
