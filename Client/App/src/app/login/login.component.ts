import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CONFIG } from '../../api/config';
import { SecurityService } from '../core/security/security.service';
import { LoginService } from './login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [ 'login.component.css' ]
})
export class LoginComponent implements OnInit {
 
  loginModel: any = {};
  loggedInUser: any = {};

  usernameOrPasswordIncorrect: boolean = false;

  @ViewChild('f') ngForm: NgForm | undefined;

  constructor(private loginService: LoginService,
    private securityService: SecurityService,
    private router: Router) { }

  ngOnInit() {
    this.securityService.logout();
  }

  onSubmit() {
    this.loginService.login(this.loginModel).subscribe(result => {
      if (result != null && result.korisnikId > 0) {
        this.usernameOrPasswordIncorrect = false;

        this.loggedInUser = result;
        this.securityService.saveToLocalStorage(this.loggedInUser);

        switch (this.loggedInUser.ulogaKorisnikaId) {
          case CONFIG.enums.ulogaKorisnikaEnum.superAdministrator:
            this.router.navigate(['/dashboard']);
            break;
          case CONFIG.enums.ulogaKorisnikaEnum.administratorUdruzenja:
            this.router.navigate(['/udruzenje']);
            break;
          case CONFIG.enums.ulogaKorisnikaEnum.korisnik:
            this.router.navigate(['/home']);
            break;
        }
      } else {
        this.usernameOrPasswordIncorrect = true;
      }
    });
  }
  
}
