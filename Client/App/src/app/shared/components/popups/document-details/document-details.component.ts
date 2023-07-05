import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CONFIG } from '../../../../../api/config';
import { ToastService } from '../../../../core/toast/toast.service';
import { DocumentService } from './document.service';
//import { FileUploadService } from '../../../../shared/components/file-upload/file-upload.service';

@Component({
  selector: 'app-document-details',
  templateUrl: './document-details.component.html',
  styleUrls: []
})
export class DocumentDetailsComponent implements OnInit {
  @Input()
  dokumentId: number = 0;
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();

  dokument: any = {};

  @ViewChild('f') ngForm: NgForm | undefined;

  uploadedFile: File | undefined;
  uploadedFileUrl: string | null = null;

  allowedFileTypes: string[] = ["application/msword", "application/vnd.ms-excel", "text/plain", "application/pdf"];
  allowedFileTypesPretty: string[] = ["pdf", "doc", "docx", "xls", "xlsx", "txt"];
  fileTypeValid: boolean = true;

  constructor(private documentService: DocumentService,
    private toastService: ToastService) { }

  ngOnInit() {
    if (this.dokumentId > 0) {
      this.documentService.getById(this.dokumentId).subscribe(result => {
        this.dokument = result;
        console.log(this.dokument);
      });
    }
  }

  saveAndCloseModal() {
    if (this.formValid()) {
      this.documentService.document = this.dokument;
      this.documentService.document$.next(this.dokument); 

      this.modalClosed.emit(true);
    }
  }

  closeModal() {
    this.modalClosed.emit(true);
  }

  formValid() {
    if (this.uploadedFile != null && this.fileTypeValid)
      return true;

    return false;
  }

  handleUpload(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    const files = inputElement.files;
    if (files && files.length > 0) {
      const file = files[0];

      if (this.allowedFileTypes.filter(x => x == file.type).length == 0) {
        this.fileTypeValid = false;
      } else {
        this.fileTypeValid = true;
        this.handleFile(file);
      }
    }
  }

  handleFile(file: File) {
    this.uploadedFile = file;
    this.readFile(file);
  }

  readFile(file: File): void {
    const reader = new FileReader();
    reader.onload = (event: any) => {
      this.uploadedFileUrl = event.target.result;
      const base64String = event.target.result.split(',')[1];

      this.dokument.base64Datoteke = base64String;
      this.dokument.nazivDatoteke = file.name;
      this.dokument.ekstenzijaDatoteke = file.name.split('.')[1];
    };
    reader.readAsDataURL(file);
  }
}
