import { TestBed } from '@angular/core/testing';

import { AutomobiliaiService } from './automobiliai.service';

describe('AutomobiliaiService', () => {
  let service: AutomobiliaiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AutomobiliaiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
