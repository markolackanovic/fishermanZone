import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-association',
  templateUrl: './association.component.html',
  styleUrls: []
})
export class AssociationComponent implements OnInit {

  openTab: number = 1;

  constructor() { }

  ngOnInit() { }

  toggleTabs($tabNumber: number) {
    this.openTab = $tabNumber;
  }
}
