import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { CONFIG } from '../../api/config';
import { ExceptionService } from '../core/exception.service';
import { SpinnerService } from '../core/spinner/spinner.service';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  constructor(private _http: HttpClient,
    private _exceptionService: ExceptionService,
    private _spinnerService: SpinnerService) { }

  createUdruzenje(udruzenje: any): Observable<number> {
    this._spinnerService.show();
    return this._http.post<number>(CONFIG.baseUrls.udruzenje.add, udruzenje)
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }

  createKorisnik(korisnik: any): Observable<number> {
    this._spinnerService.show();
    return this._http.post<number>(CONFIG.baseUrls.korisnik.add, korisnik)
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }
}
