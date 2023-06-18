import { Component } from '@angular/core';
import { SecurityService } from './core/security/security.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Client';

  public currentUser: any;

  menuShow: boolean = true;

  constructor(private securityService: SecurityService) { }

  ngOnChanges() {
    this.securityService.currentUser.subscribe(user => {
      this.currentUser = user;

      //this.setLoggedUserName();
    });
  }

  toggleNavbar() { }

  toggleDropdown(event: any) {

  }


}
