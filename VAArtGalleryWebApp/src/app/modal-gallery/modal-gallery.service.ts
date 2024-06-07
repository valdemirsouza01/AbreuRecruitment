import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ArtGalleryRequest } from './models';

@Injectable({
  providedIn: 'root'
})
export class ModalGalleryService {

  private baseUrl = 'https://localhost:7042/api/art-galleries'

  constructor(private http: HttpClient) { }

  addGallery(request: ArtGalleryRequest) {
    return this.http.post(`${this.baseUrl}`, request);
  }

  updateGallery(idGallery: string, request: ArtGalleryRequest) {
    return this.http.put(`${this.baseUrl}/${idGallery}`, request);
  }

}
