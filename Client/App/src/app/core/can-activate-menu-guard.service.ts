import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, Route, RouterStateSnapshot,  } from '@angular/router';
import { Observable, of, } from 'rxjs';
import { SecurityService } from './security/security.service';
import { SpinnerService } from './spinner/spinner.service';
import { ExceptionService } from './exception.service';

import { CanActivateModel } from './models/admin/access-rights/can-activate.model';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class CanActivateMenuGuardService implements CanActivate {
  public canActivateModel: CanActivateModel = <CanActivateModel>{};
  public accesRightID: number = 0;
  public canActivateLink: boolean = true;;
  public AccessRightID() {
    return this.accesRightID;
  }
  constructor(private http: HttpClient,
    private router: Router,
    private securityService: SecurityService,
    private exceptionService: ExceptionService,
    private spinnerService: SpinnerService) {
  }

  canLoad(route: Route) {
  
    if (this.securityService.isLoggedIn) {
      return true;
    }

    let url = `/${route.path}`;
    this.router.navigate(['/login'], { queryParams: { redirectTo: url } });
    return this.securityService.isLoggedIn;
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    if (this.securityService.isLoggedIn) {
      return of(true);
    }

    return of(false);
  }
}
