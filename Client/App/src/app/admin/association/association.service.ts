import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { CONFIG } from '../../../api/config';
import { ExceptionService } from '../../core/exception.service';
import { SpinnerService } from '../../core/spinner/spinner.service';

@Injectable({
  providedIn: 'root'
})
export class AssociationService {

  constructor(private _http: HttpClient,
    private _exceptionService: ExceptionService,
    private _spinnerService: SpinnerService) { }

  getById(id: number): Observable<any> {
    this._spinnerService.show();
    return this._http.get<any>(CONFIG.baseUrls.udruzenje.getById + id )
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }

  saveUdruzenje(udruzenje: any): Observable<number> {
    this._spinnerService.show();
    return this._http.post<number>(CONFIG.baseUrls.udruzenje.save, udruzenje)
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }
}
