import { Injectable } from '@angular/core';
/*import { Response } from '@angular/common/http';*/
import { Observable,of } from 'rxjs';
import { Router } from '@angular/router';
import { ResponsePackageModel } from '../../api/response-package.model';
import { ToastService } from './toast/toast.service';
import { LanguageService } from './language/language.service';


@Injectable({
  providedIn: 'root'
})
export class ExceptionService {
    constructor(
        private toastService: ToastService,
      private router: Router,
      private languageService: LanguageService) { }

    catchBadResponse: (errorResponse: any) => Observable<any> = (errorResponse: any) => {
        let msg = "";

        console.log("ERROR:", errorResponse);
     
        if (errorResponse.status == 403) {
            msg = "forbriden";

            let msgInfo = "";

            if (errorResponse._body != null && errorResponse._body != undefined) {
                var resp: ResponsePackageModel = JSON.parse(errorResponse._body);
                if (resp.errors != null && resp.errors.length > 0) {
                    for (let entry of resp.errors) {
                        if (msgInfo == "") {
                            msgInfo = entry;
                        }
                        else {
                            msgInfo = msgInfo + " " + entry;
                        }
                    }
                }
            }

            if (msgInfo.length)
                msg = msgInfo;
        }
        else if (errorResponse.status == 400) {
            let msgInfo = "";

            if (errorResponse.error != null && errorResponse.error != undefined) {
                let validationErrorDictionary = errorResponse.error.errors;
                for (var fieldName in validationErrorDictionary) {
                    if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                        msgInfo = errorResponse.error.errors[fieldName];
                        break;
                    }
                }
            }

          if (msgInfo.length) {
            msg = this.languageService.translate("poruka_sistema") + this.languageService.translate(msgInfo);
            }

        }        
        else if (errorResponse.status == 401) {
            this.router.navigate(['/login'])
            msg = "Vaša sesija je istekla. Prijavite se ponovo na sistem.";
        }
        else if (errorResponse.status == 500) {
            msg = "Dogodila se greška. Obratite se administratoru sistema.";
        }
        else if (errorResponse.status == 0) {
            msg = "Servis nije dostupan. Obratite se administratoru sistema.";
        }
       
        else {
            msg = "Dogodila se greška. Obratite se administratoru sistema.";
        } 
      if (msg != "") {
            this.toastService.activate(msg, "alert-dangerToast");
        }

        return of(false);
    };
}

