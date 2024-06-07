import { Component, OnInit } from '@angular/core';
import { Gallery } from './models';
import { GalleryService } from './gallery.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ModalGalleryComponent } from '../modal-gallery/modal-gallery.component';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrl: './gallery.component.css',
})

export class GalleryComponent implements OnInit {

  galleries: Gallery[] = [];
  displayedColumns: string[] = ['name', 'city', 'manager', 'nbrWorks', 'actions'];

  constructor(private galleryService: GalleryService
    , private dialog: MatDialog
    , private router: Router) {
  }

  ngOnInit(): void {
    this.loadGalleries();
  }

  loadGalleries() {
    this.galleryService.getGalleries().subscribe(galleries => { this.galleries = galleries; });
  }

  editGalleryClick(galleryId: string) {
    
    const gallery = this.galleries.find(g => g.id === galleryId);

    if (gallery) {
      this.openDialog(gallery);
    }
  }

  openArtWorksList(galleryId: string) {
    this.router.navigate(['/art-works', galleryId]);
  }

  openDialog(gallery: Gallery | null = null) {
    const dialogRef = this.dialog.open(ModalGalleryComponent, {
      width: '600px',
      height: '450px',
      data: gallery,
      enterAnimationDuration: 700,
    });

    dialogRef.afterClosed().subscribe(result => {
      this.loadGalleries();
    });

    
  }
}
