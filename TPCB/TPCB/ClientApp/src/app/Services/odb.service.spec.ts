import { TestBed } from '@angular/core/testing';

import { OdbService } from './odb.service';

describe('OdbService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OdbService = TestBed.get(OdbService);
    expect(service).toBeTruthy();
  });
});
