import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AssociationService } from '../association.service';

@Component({
  selector: 'app-association-profile',
  templateUrl: './association-profile.component.html',
  styleUrls: []
})
export class AssociationProfileComponent implements OnInit {

  @Input()
  udruzenje: any;

  @Output() dataChanged: EventEmitter<boolean> = new EventEmitter<boolean>();

  showModal: boolean = false;

  constructor(private associationService: AssociationService) { }

  ngOnInit() {
  }

  openAssociationEditModal() {
    this.showModal = true;
  }

  modalClosed() {
    this.showModal = false;

    this.dataChanged.emit(true);

    this.associationService.getById(this.udruzenje.udruzenjeId).subscribe(result => {
      this.udruzenje = result;
    });
  }
}
