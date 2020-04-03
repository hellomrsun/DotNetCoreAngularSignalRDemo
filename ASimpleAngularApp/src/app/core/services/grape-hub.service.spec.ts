import { TestBed } from '@angular/core/testing';

import { GrapeHubService } from './grape-hub.service';

describe('GrapeHubService', () => {
  let service: GrapeHubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GrapeHubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
