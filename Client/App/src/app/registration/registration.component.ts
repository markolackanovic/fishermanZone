import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: []
})
export class RegistrationComponent implements OnInit {

  parentAssociations: any[] = [
    { value: 'rs', viewValue: 'Ribolovački savez Republike Srpske' },
    { value: 'fbih', viewValue: 'Ribolovački savez Federacije BiH' },
    { value: 'brcko', viewValue: 'Ribolovački savez Brčko distrikta' },
  ];

  places: any[] = [
    { value: 'sarajevo', viewValue: 'Sarajevo' },
    { value: 'doboj', viewValue: 'Doboj' },
    { value: 'brcko', viewValue: 'Brčko' },
  ];


  submitted = false;

  constructor() {
  }

  onSubmit() {



  }
  ngOnInit() {

  }

}
