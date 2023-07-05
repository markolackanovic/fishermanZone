import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';;
import { CONFIG } from '../../../../../api/config';
import { ExceptionService } from '../../../../core/exception.service';
import { SpinnerService } from '../../../../core/spinner/spinner.service';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  document: any | null = null;

  document$ = new Subject<any>();

  constructor(private _http: HttpClient,
    private _exceptionService: ExceptionService,
    private _spinnerService: SpinnerService) { }

  saveDokument(dokument: any): Observable<number> {
    this._spinnerService.show();
    return this._http.put<number>(CONFIG.baseUrls.dokument.save, dokument)
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }

  getById(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.get<any>(CONFIG.baseUrls.dokument.getById + id)
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }

  download(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.get(CONFIG.baseUrls.dokument.download + id, { responseType: 'text' })
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }
}
