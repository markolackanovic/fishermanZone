import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  uploadedFile: File | null = null;

  fileUploaded$ = new Subject<File>();

  constructor() { }
}
