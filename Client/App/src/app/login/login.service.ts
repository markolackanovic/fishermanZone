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
export class LoginService {

  constructor(private _http: HttpClient,
    private _exceptionService: ExceptionService,
    private _spinnerService: SpinnerService) { }

  login(loginModel: any): Observable<any> {
    this._spinnerService.show();
    return this._http.post<any>(CONFIG.baseUrls.login, loginModel)
      .pipe(
        catchError(this._exceptionService.catchBadResponse),
        finalize(() => this._spinnerService.hide())
      );
  }
}
