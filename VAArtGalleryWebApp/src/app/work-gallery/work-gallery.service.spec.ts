/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { WorkGalleryService } from './work-gallery.service';

describe('Service: WorkGallery', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WorkGalleryService]
    });
  });

  it('should ...', inject([WorkGalleryService], (service: WorkGalleryService) => {
    expect(service).toBeTruthy();
  }));
});
