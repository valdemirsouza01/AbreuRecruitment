import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ArtWork, ArtWorkRequest } from './models';



@Injectable({
  providedIn: 'root'
})
export class WorkGalleryService {

  private baseUrl = 'https://localhost:7042/api/art-works'

  constructor(private http: HttpClient) { }

  getAllArtWorks(galleryId: string) {
    return this.http.get<ArtWork[]>(`${this.baseUrl}/${galleryId}`);
  }

  addArtWork(id: string, request: ArtWorkRequest) {
    return this.http.post(`${this.baseUrl}/${id}`, request);
  }

}
