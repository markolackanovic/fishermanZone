import { Component, AfterViewInit, ViewChild, ElementRef } from "@angular/core";
import { Router } from "@angular/router";
import { createPopper } from "@popperjs/core";
import { SecurityService } from '../core/security/security.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: []
})
export class NavbarComponent implements AfterViewInit {

  dropdownPopoverShow = false;
  @ViewChild("btnDropdownRef", { static: false }) btnDropdownRef: ElementRef | undefined;
  @ViewChild("popoverDropdownRef", { static: false })
  popoverDropdownRef: ElementRef | undefined;

  public currentUser: any = {};

  constructor(private securityService: SecurityService,
    private router: Router) {
    this.securityService.currentUser.subscribe(x => {
      this.currentUser = x;

      console.log(this.currentUser);
    });
  }

  ngAfterViewInit() {
    if (this.btnDropdownRef != null && this.popoverDropdownRef != null) {
      createPopper(
        this.btnDropdownRef?.nativeElement,
        this.popoverDropdownRef?.nativeElement,
        {
          placement: "bottom-start",
        }
      );
    }
  }

  toggleDropdown(event: any) {
    event.preventDefault();
    if (this.dropdownPopoverShow) {
      this.dropdownPopoverShow = false;
    } else {
      this.dropdownPopoverShow = true;
    }
  }

  toggleNavbar() { }

  logout() {
    this.securityService.logout();
    this.router.navigate(['/home']);
  }
}
