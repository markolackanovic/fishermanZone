import { Component } from '@angular/core';
import { SecurityService } from './core/security/security.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent {
  title = 'Client';

 
  constructor(private securityService: SecurityService) {
    
  }

  ngOnInit() {

  }
}
