import { Component, OnInit, OnDestroy } from '@angular/core';
import { SpinnerService, SpinnerState } from './spinner.service';
import { Subscription } from 'rxjs';


@Component({
    selector: 'app-spinner',
    templateUrl: './spinner.component.html',
    styleUrls: ['./spinner.component.css']
})
export class SpinnerComponent implements OnInit, OnDestroy {
  public spinnerStateChanged: Subscription = new Subscription;
    public visible = false;

    constructor(private spinnerService: SpinnerService) { }

    ngOnInit() {
        this.spinnerStateChanged = this.spinnerService.spinnerState
            .subscribe((state: SpinnerState) => this.visible = state.show);
    }

    ngOnDestroy() {
        this.spinnerStateChanged.unsubscribe();
    }
}
