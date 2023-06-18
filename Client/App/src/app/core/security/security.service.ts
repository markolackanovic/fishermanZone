import { Injectable } from '@angular/core';
/*import { Http, Headers, Response, RequestOptions, RequestMethod } from '@angular/common/http';*/
import { UrlAccessRight } from './../models/admin/access-rights/url-access-right.model';
import { LoginResponseModel } from '../../login/login-response.model';
import { LoggedInUserModel } from './../models/admin/login/logged-in-user.model';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  public _token: string | undefined;
  public _isLoggedIn: boolean | undefined;

  public accessRigthId: number = 0;
  private currentUserSubject: BehaviorSubject<LoggedInUserModel>;
  public currentUser: Observable<LoggedInUserModel>;

  constructor() {
    this.currentUserSubject = new BehaviorSubject<LoggedInUserModel>(JSON.parse(localStorage.getItem('currentUser')!));
    this.currentUser = this.currentUserSubject.asObservable();
  }


  public get token(): string {
    let currentUser: LoginResponseModel = JSON.parse(localStorage.getItem('currentUser') || '{}');
    this._token = currentUser.token || '{}';

    return this._token;
  }

  public getApiTokenInfo(): any {
    return {
      apiToken: JSON.parse(localStorage.getItem('currentUser')!).apitoken,
      date: JSON.parse(localStorage.getItem('currentUser')!).apitokenDateCreated
    }
  }

  public get isLoggedIn() {
    this._isLoggedIn = false;

    if (localStorage.getItem('currentUser')) {
      let currentUser: LoginResponseModel = JSON.parse(localStorage.getItem('currentUser') || '{}');

      if (currentUser.isLoggedIn)
        this._isLoggedIn = true;
      else
        this._isLoggedIn = false;
    }
    else {
      this._isLoggedIn = false
    }
    return this._isLoggedIn;
  }

  logout() {
    localStorage.removeItem('currentUser');

    this.currentUserSubject.next(new LoggedInUserModel());
  }

  saveToLocalStorage(loggedUserModel: LoggedInUserModel) {
    localStorage.setItem('currentUser', JSON.stringify(loggedUserModel));
    this.currentUserSubject.next(loggedUserModel);
  }

  getCurrentUserFullName(): string {
    var currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
    let currentUserName = '';
    if (currentUser != null) {
      currentUserName = currentUser.firstName + ' ' + currentUser.lastName;
    }
    return currentUserName;
  }

  getLevelAccessRight(menuItemId: number): number {
    let urlAdditionalAccessRight = localStorage.getItem("urlAdditionalAccessRight");

    if (urlAdditionalAccessRight != null) {
      let urlAccessRights: UrlAccessRight[] = JSON.parse(urlAdditionalAccessRight);
      let urlAR = urlAccessRights.filter(x => x.menuItemID == menuItemId)[0];
      if (urlAR != null) {
        return urlAR.levelAccessRightID || 0;
      }
      else {
        return 0;
      }
    }
    return 0;
  }
}
