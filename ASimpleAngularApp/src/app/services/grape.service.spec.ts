import { TestBed } from '@angular/core/testing';

import { GrapeService } from './grape.service';

describe('GrapeService', () => {
  let service: GrapeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GrapeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
