import { Component, EventEmitter, Output } from '@angular/core';
import { FileUploadService } from './file-upload.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html'
})
export class FileUploadComponent {

  uploadedFile: File | null = null;
  uploadedFileUrl: string | null = null;

  constructor(private fileService: FileUploadService) { }

  handleDragOver(event: DragEvent) {
    event.preventDefault();
    const dropzone = event.target as HTMLElement;
    dropzone.classList.add('border-blue-500');
  }

  handleDragLeave(event: DragEvent) {
    event.preventDefault();
    const dropzone = event.target as HTMLElement;
    dropzone.classList.remove('border-blue-500');
  }

  handleDrop(event: DragEvent) {
    event.preventDefault();
    const dropzone = event.target as HTMLElement;
    dropzone.classList.remove('border-blue-500');
    const file = event.dataTransfer?.files[0];
    if (file) {
      this.handleImage(file);
    }
  }

  handleImageUpload(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const files = inputElement.files;
    if (files && files.length > 0) {
      const file = files[0];
      this.handleImage(file);
    }
  }

  handleImage(file: File) {
    this.uploadedFile = file;
    this.fileService.uploadedFile = file;
    this.fileService.fileUploaded$.next(file);

    this.readFile(file);
  }

  readFile(file: File): void {
    const reader = new FileReader();
    reader.onload = (event: any) => {
      this.uploadedFileUrl = event.target.result;
    };
    reader.readAsDataURL(file);
  }

  deleteLogo() {
    this.uploadedFile = null;
    this.uploadedFileUrl = null;
    this.fileService.uploadedFile = null;
  }
}
