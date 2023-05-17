import { Injectable, Inject } from '@angular/core';
//import { Language } from '../models/language';
//import { TRANSLATIONS } from './translations/translations';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  //  private _selectedLanguageId: number=1;
  //private _supportedLangs: Language[] = [];
  //public supportedLangs: Language[] = [{ id: 1, name: 'Bosanski', code: 'bs' }, { id: 2, name: 'Hrvatski', code: 'hr' }, { id: 1, name: 'Srpski', code: 'sr' }, { id: 1, name: 'Engleski', code: 'en' }];
  //private _selectedLanguage: string = "bs";
  //constructor(@Inject(TRANSLATIONS) private _translations: any,
  //  private _http: HttpClient) {

  //}
  //public get selectedLanguage() {

  //  return this._selectedLanguage;
  //}

  //public set selectedLanguage(value: string) {

  //  this._selectedLanguage = value;
  //}
  //public use(lang: string): void {
  //  localStorage.setItem('currentLanguage', lang);
  //  this.selectedLanguage = lang;
  //}

  public translate(key: string): string {
    //if (!localStorage.getItem('currentLanguage')) {
    //  this.use('bs');
    //}
    //let translation = key;
    //if (this._translations[localStorage.getItem('currentLanguage')!] && this._translations[localStorage.getItem('currentLanguage')!][key]) {
    //  return this._translations[localStorage.getItem('currentLanguage')!][key];
    //}

    //return translation;
    return "";
  }

  public instant(key: string) {
    return this.translate(key);
  }
  //getCurrentLanguageId(): number {

  //  switch (localStorage.getItem('currentLanguage')) {
  //    case 'bs': {
  //      return 1;
  //    }
  //    case 'hr': {

  //      return 2;
  //    }
  //    case 'sr': {
  //      return 3;
  //    }
  //    case 'en': {

  //      return 4;
  //    }
  //  }
  //  return 0;
  }


