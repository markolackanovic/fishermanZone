import { Injectable } from '@angular/core';
import { BehaviorSubject } from "rxjs";
import { Observable } from "rxjs";

@Injectable()
export class GlobalEventsManagerService {

    public _loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    public loggedInEmitter: Observable<boolean> = this._loggedIn.asObservable();

    constructor() { }

    loggedIn(ifShow: boolean) {
        this._loggedIn.next(ifShow);
    }
}
