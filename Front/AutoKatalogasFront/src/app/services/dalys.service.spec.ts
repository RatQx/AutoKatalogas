import { TestBed } from '@angular/core/testing';

import { DalysService } from './dalys.service';

describe('DalysService', () => {
  let service: DalysService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DalysService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
