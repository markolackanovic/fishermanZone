import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-association-profile',
  templateUrl: './association-profile.component.html',
  styleUrls: []
})
export class AssociationProfileComponent implements OnInit {

  showModal: boolean = false;
  ngOnInit() { }

  openAssociationEditModal() {
    this.showModal = !this.showModal;
    console.log(this.showModal);
  }
}
