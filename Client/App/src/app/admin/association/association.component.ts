import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AssociationService } from './association.service';

@Component({
  selector: 'app-association',
  templateUrl: './association.component.html',
  styleUrls: []
})
export class AssociationComponent implements OnInit {

  openTab: number = 1;

  udruzenje: any = {};

  constructor(private route: ActivatedRoute, private associationService: AssociationService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let id = +params['id'];

      if (!isNaN(id) && id > 0) {
        this.getUdruzenjeById(id);
      }
    });
  }

  getUdruzenjeById(udruzenjeId: number) {
    this.associationService.getById(udruzenjeId).subscribe(x => {
      this.udruzenje = x.result;
    });
  }

  toggleTabs($tabNumber: number) {
    this.openTab = $tabNumber;
  }

  dataChanged() {
    this.associationService.getById(this.udruzenje.udruzenjeId).subscribe(result => {
      this.udruzenje = result;
    });
  }
}
