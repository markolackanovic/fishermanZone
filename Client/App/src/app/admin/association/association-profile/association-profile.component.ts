import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AssociationService } from '../association.service';
import { trigger, transition, style, animate } from '@angular/animations';
import { DocumentService } from '../../../shared/components/popups/document-details/document.service';

@Component({
  selector: 'app-association-profile',
  templateUrl: './association-profile.component.html',
  styleUrls: [],
  animations: [
    trigger('fadeIn', [
      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(-10px)' }),
        animate('500ms', style({ opacity: 1, transform: 'translateY(0)' })),
      ]),
    ]),
  ]
})
export class AssociationProfileComponent implements OnInit {

  @Input()
  udruzenje: any;

  @Output() dataChanged: EventEmitter<boolean> = new EventEmitter<boolean>();

  showModal: boolean = false;

  constructor(private associationService: AssociationService, private documentService: DocumentService) { }

  ngOnInit() {
  }

  openAssociationEditModal() {
    this.showModal = true;
  }

  modalClosed() {
    this.showModal = false;

    this.dataChanged.emit(true);

    this.associationService.getById(this.udruzenje.udruzenjeId).subscribe(result => {
      this.udruzenje = result.result;
    });
  }

  downloadDocument(doc: any) {
    console.log(doc);
    this.documentService.download(doc.dokumentId).subscribe(result => {
      const binaryString = window.atob(result);
      const bytes = new Uint8Array(binaryString.length);
      for (let i = 0; i < binaryString.length; i++) {
        bytes[i] = binaryString.charCodeAt(i);
      }

      const blob = new Blob([bytes], { type: 'application/octet-stream' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = doc.nazivDatoteke + '.' + doc.ekstenzijaDatoteke;
      a.click();
      window.URL.revokeObjectURL(url);
    });
  }
}
