import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-association-profile-edit',
  templateUrl: './association-profile-edit.component.html',
  styleUrls: []
})
export class AssociationProfileEditComponent implements OnInit {

  @Input()
  showModal: boolean = false;

  constructor() { }

  ngOnInit() {
    console.log(this.showModal);
  }

  toggleModal() {
    this.showModal = !this.showModal;
  }
}
