import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { SecurityService } from '../security/security.service';
import { ExceptionService } from '../exception.service';


@Injectable()
export class AuthHttpInterceptor implements HttpInterceptor {
    constructor(private securityService: SecurityService,
        private exceptionService: ExceptionService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req.headers.append("Content-Type", "application/json; charset=utf-8");
    
        if (req.url.includes("LoginAdmin/Login") && req.url.includes("LoginAdmin/GenerateToken") && !req.url.includes("change-password") && !req.url.includes("saveLoginAudit")) {

            return next.handle(req)
                .pipe(catchError(this.exceptionService.catchBadResponse));
        }

       
        const authReq = req.clone({ headers: req.headers.append("Authorization", 'Bearer ' + this.securityService.token) })
        return next.handle(authReq)
            .pipe(catchError(this.exceptionService.catchBadResponse));
    }
}
