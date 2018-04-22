import { TestBed, inject } from '@angular/core/testing';

import { BoissonService } from './boisson.service';

describe('BoissonService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BoissonService]
    });
  });

  it('should be created', inject([BoissonService], (service: BoissonService) => {
    expect(service).toBeTruthy();
  }));
});
