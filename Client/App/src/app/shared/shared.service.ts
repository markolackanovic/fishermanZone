import { Injectable } from '@angular/core';
import { Observable, catchError, finalize } from 'rxjs';
/*import { Response } from '@angular/http';*/
import { HttpClient } from '@angular/common/http';
import { CONFIG } from '../../api/config';
import { ResponsePackageModel } from '../../api/response-package.model';
import { ExceptionService } from '../core/exception.service';
import { SpinnerService } from '../core/spinner/spinner.service';
import { SecurityService } from './../core/security/security.service';
import { CanActivateModel } from '../core/models/admin/access-rights/can-activate.model';
//import { CheckLevelAccessRightModel } from '../core/models/admin/access-rights/level-access-right-model';
//import { UserLevelAccessRightModel } from '../core/models/admin/access-rights/user-level-access-right.model';
import { map } from 'rxjs/operators';


@Injectable()
export class SharedService {
  constructor(private http: HttpClient,
    private exceptionService: ExceptionService,
    private spinnerService: SpinnerService,
    private securityService: SecurityService) { }
  //getNavMenu(): Observable<ResponsePackageModel> {
  //  this.spinnerService.show();
  //  return this.http.get(CONFIG.baseUrls.nav.getNavMenu)
  //    .pipe(catchError(this.exceptionService.catchBadResponse))
  //    .pipe(finalize(() => { this.spinnerService.hide(); }));
  //}

}
