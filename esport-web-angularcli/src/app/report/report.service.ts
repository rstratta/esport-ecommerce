import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router, ActivatedRoute } from '@angular/router';
import { UrlBackendProvider } from '../urlBackendProvider';
import { ResponseHandler } from '../response/responseHandler';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';
@Injectable()
export class ReportService {



  constructor(
    private http: Http, private router: Router,
    private userContext: UserContext,
    private urlBackendProvider: UrlBackendProvider, private responseHandler: ResponseHandler) { }



  productsMoreSaled(quantity:number): Observable<any> {
       let header=new Headers();
        header.append('Token',this.userContext.Token);
    return (this.http.get(this.urlBackendProvider.getBaseDir() + "/productReport?quantity="+quantity, {headers:header}).
    map(response => response.json())).map(reportResponse => {
      return reportResponse;
    });
  }

 categoryReport(initDate:string, finishDate:string): Observable<any> {
       let header=new Headers();
        header.append('Token',this.userContext.Token);
    return (this.http.get(this.urlBackendProvider.getBaseDir() + "/categoryReport?startDate="+initDate+"&finishDate="+finishDate, {headers:header}).
    map(response => response.json())).map(reportResponse => {
      return reportResponse;
    });
  }
}