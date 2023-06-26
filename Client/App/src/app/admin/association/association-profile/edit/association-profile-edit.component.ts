import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SearchCountryField, CountryISO, PhoneNumberFormat } from 'ngx-intl-tel-input';
import { CONFIG } from '../../../../../api/config';
import { ToastService } from '../../../../core/toast/toast.service';
import { FileUploadService } from '../../../../shared/components/file-upload/file-upload.service';
import { SharedService } from '../../../../shared/shared.service';
import { AssociationService } from '../../association.service';

@Component({
  selector: 'app-association-profile-edit',
  templateUrl: './association-profile-edit.component.html',
  styleUrls: []
})
export class AssociationProfileEditComponent implements OnInit {
  @Input()
  udruzenjeId: number = 0;
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();

  udruzenje: any = {};

  udruzenja: any[] = [];
  admJedinice: any[] = [];

  kontaktTelefon: any = {};

  SearchCountryField = SearchCountryField;
  CountryISO = CountryISO;
  PhoneNumberFormat = PhoneNumberFormat;
  preferredCountries: CountryISO[] = [CountryISO.BosniaAndHerzegovina];
  customPlaceholder = "062 123 456";

  @ViewChild('f') ngForm: NgForm | undefined;

  uploadedFile: File | undefined;
  uploadedFileUrl: string | null = null;

  constructor(private associationService: AssociationService,
    private sharedService: SharedService,
    private fileService: FileUploadService,
    private toastService: ToastService) { }

  ngOnInit() {
    this.associationService.getById(this.udruzenjeId).subscribe(result => {
      this.udruzenje = result;

      console.log(this.udruzenje);

      this.kontaktTelefon = this.udruzenje.kontaktTelefon;

      this.initCodeLists();

      this.subscribeToFileUpload();
    });
  }

  initCodeLists() {
    this.sharedService.getAdministrativneJediniceForDropdown(0).subscribe(result => {
      this.admJedinice = result;
    });

    this.sharedService.getUdruzenjaForDropdown(0, CONFIG.enums.udruzenjaEnum.SRSBiH).subscribe(result => {
      this.udruzenja = result;
    });
  }

  saveAndCloseModal() {
    this.udruzenje.kontaktTelefon = this.kontaktTelefon.nationalNumber;

    if (this.formValid()) {
      this.associationService.updateUdruzenje(this.udruzenje).subscribe(result => {
        this.modalClosed.emit(true);
        this.toastService.activate("Profilni podaci udruženja izmijenjeni", "toast-success");
      });   
    }
  }

  closeModal() {
    this.modalClosed.emit(true);
  }

  formValid() {
    if (this.udruzenje.nadredjenoUdruzenjeId > 0 && this.udruzenje.administrativnaJedinicaId > 0 &&
      this.udruzenje.naziv?.length >= 3 && this.udruzenje.adresa?.length >= 3 &&
      this.udruzenje.opis?.length >= 20)
      return true;

    return false;
  }

  subscribeToFileUpload() {
    this.fileService.fileUploaded$.subscribe((file: File) => {
      this.uploadedFile = file;

      this.udruzenje.nazivLogoDatoteke = this.uploadedFile.name;

      const reader = new FileReader();
      reader.onload = (event: any) => {
        const base64String = event.target.result.split(',')[1]; // Uzimamo samo dio Base64 stringa bez prefiksa
        this.udruzenje.base64Logo = base64String;
      };
      reader.readAsDataURL(file);
    });
  }

  deleteLogo() {
    this.udruzenje.base64Logo = null;
    this.udruzenje.base64LogoDatoteke = null;
    this.udruzenje.ekstenzijaLogoDatoteke = null;
    this.udruzenje.nazivLogoDatoteke = null;
  }
}
