import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatLabel } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { ArtGalleryRequest } from './models';
import { ModalGalleryService } from './modal-gallery.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Gallery } from '../gallery/models';


@Component({
  selector: 'app-modal-gallery',
  templateUrl: './modal-gallery.component.html',
  styleUrl: './modal-gallery.component.css',
  standalone: true,
  imports: [MatLabel
    , ReactiveFormsModule
    , MatButtonModule
    , MatDialogModule
    , FormsModule
    , MatFormFieldModule
    , MatInputModule
    , MatTableModule
    , MatIconModule

  ],
})
export class ModalGalleryComponent {

  request: ArtGalleryRequest = {
    name: '',
    city: '',
    manager: ''
  };

  formGallery = new FormGroup({
    id: new FormControl(''),
    name: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    manager: new FormControl('', Validators.required)
  });

  constructor(private modalGalleryService: ModalGalleryService
    , @Inject(MAT_DIALOG_DATA) public dataGallery: Gallery
    , public dialogRef: MatDialogRef<ModalGalleryComponent>
  ) { }

  ngOnInit(): void {
    if (this.dataGallery) {
      this.formGallery.setValue({
        id: this.dataGallery.id,
        name: this.dataGallery.name,
        city: this.dataGallery.city,
        manager: this.dataGallery.manager
      });
    }
  }

  addGallery() {

    if (this.formGallery.invalid) {
      return;
    }

    this.request.name = this.formGallery.value.name ?? '';
    this.request.city = this.formGallery.value.city ?? '';
    this.request.manager = this.formGallery.value.manager ?? '';


    this.modalGalleryService.addGallery(this.request).subscribe({
      next: (response) => {
        console.log(response);
        this.dialogRef.close();
      },
      error: (error) => {
        alert('An error occurred');
      }
    });

  }

  editGallery() {
    console.log('editGallery');
  }

  updateGallery() {

    if (this.formGallery.invalid && this.formGallery.value.id === '') {
      return;
    }

    const id = this.formGallery.value.id ?? '';
    this.request.name = this.formGallery.value.name ?? '';
    this.request.city = this.formGallery.value.city ?? '';
    this.request.manager = this.formGallery.value.manager ?? '';

    this.modalGalleryService.updateGallery(id, this.request).subscribe({
      next: (response) => {
        console.log(response);
        this.dialogRef.close();
      },
      error: (error) => {
        alert('An error occurred');
      }
    });
  }

}
