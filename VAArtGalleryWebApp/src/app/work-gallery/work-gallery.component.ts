import { Component, OnInit } from '@angular/core';
import { WorkGalleryService } from './work-gallery.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ArtWork, ArtWorkRequest } from './models';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { DecimalPipe } from '@angular/common';
import { MatInputModule } from '@angular/material/input';


@Component({
  selector: 'app-work-gallery',
  templateUrl: './work-gallery.component.html',
  styleUrl: './work-gallery.component.css',
  standalone: true,
  imports: [
    MatLabel
    , ReactiveFormsModule
    , MatButtonModule
    , FormsModule
    , MatFormFieldModule
    , MatInputModule
    , MatTableModule
    , MatIconModule
    , DecimalPipe
  ]
})
export class WorkGalleryComponent implements OnInit {


  listArtWorks: ArtWork[] = [];
  displayedColumns: string[] = ['name', 'author', 'creationYear', 'askPrice'];
  galleryId = '';

  formArtWork = new FormGroup({
    id: new FormControl(''),
    name: new FormControl('', Validators.required),
    author: new FormControl('', Validators.required),
    creationYear: new FormControl('', Validators.required),
    askPrice: new FormControl('', Validators.required)

  });

  constructor(private workGalleryService: WorkGalleryService
    , private router: ActivatedRoute
    , private navigateRouter: Router
  ) { }

  ngOnInit(): void {
    this.loadArtWorks();
  }

  loadArtWorks() {
    this.galleryId = this.router.snapshot.params['galleryId'];
    this.workGalleryService.getAllArtWorks(this.galleryId).subscribe(artWorks => {
      this.listArtWorks = artWorks;
    }
    );
  }

  backGalleries() {
    this.navigateRouter.navigate(['/art-galleries']);
  }

  addArtWork() {
    
    const request: ArtWorkRequest = {
      name: this.formArtWork.value.name ?? '',
      author: this.formArtWork.value.author ?? '',
      creationYear: Number(this.formArtWork.value.creationYear ?? 0),
      askPrice: Number(this.formArtWork.value.askPrice ?? 0)
    }

    this.workGalleryService.addArtWork(this.galleryId, request).subscribe({
      next: (response) => {
        console.log(response);
        this.loadArtWorks();
        this.formArtWork.reset();
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

}
