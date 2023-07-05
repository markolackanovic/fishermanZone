import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SearchCountryField, CountryISO, PhoneNumberFormat } from 'ngx-intl-tel-input';
import { CONFIG } from '../../../../api/config';
import { ToastService } from '../../../core/toast/toast.service';
import { SharedService } from '../../../shared/shared.service';
import { AssociationsService } from '../associations.service';

@Component({
  selector: 'app-association-registration',
  templateUrl: './association-registration.component.html',
  styleUrls: []
})
export class AssociationRegistrationComponent implements OnInit {

  registrationModel: any = {
    nadredjenoUdruzenjeId: 0,
    administrativnaJedinicaId: 0
  };

  administrator: any = {
    password: null,
    repeatedPassword: null
  }

  udruzenja: any[] = [];
  admJedinice: any[] = [];

  telefonUdruzenja: any = {};
  telefonAdministratora: any = {};

  SearchCountryField = SearchCountryField;
  CountryISO = CountryISO;
  PhoneNumberFormat = PhoneNumberFormat;
  preferredCountries: CountryISO[] = [CountryISO.BosniaAndHerzegovina];
  customPlaceholder = "062 123 456";

  @ViewChild('f') ngForm: NgForm | undefined;

  constructor(private associationRegistrationService: AssociationsService,
    private sharedService: SharedService, private toastService: ToastService) {

  }

  ngOnInit() {
    this.sharedService.getAdministrativneJediniceForDropdown(0).subscribe(result => {
      this.admJedinice = result;
    });

    this.sharedService.getUdruzenjaForDropdown(0, CONFIG.enums.udruzenjaEnum.SRSBiH).subscribe(result => {
      this.udruzenja = result;
    });
  }

  onSubmit() {
    this.registrationModel.telefon = this.telefonUdruzenja.e164Number;
    this.administrator.telefon = this.telefonAdministratora.e164Number;

    if (this.formValid()) {
      this.associationRegistrationService.saveUdruzenje(this.registrationModel).subscribe(result => {
        this.administrator.udruzenjeId = result;
        this.administrator.ulogaKorisnikaId = CONFIG.enums.ulogaKorisnikaEnum.administratorUdruzenja;

        this.associationRegistrationService.createKorisnik(this.administrator).subscribe(result => {
          this.toastService.activate("Profil udruženja uspješno kreiran", "toast-success");
        });
      });
    }
  }

  formValid() {
    if (this.registrationModel.nadredjenoUdruzenjeId > 0 && this.registrationModel.administrativnaJedinicaId > 0 &&
      this.registrationModel.naziv?.length >= 3 && this.registrationModel.adresa?.length >= 3 &&
      this.registrationModel.opis?.length >= 20 && this.administrator.ime?.length >= 3 && this.administrator.prezime?.length >= 3 &&
      this.administrator.lozinka?.length >= 8 && this.administrator.lozinka == this.administrator.repeatedPassword)
      return true;

    return false;
  }
}
