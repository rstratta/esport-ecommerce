import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router } from '@angular/router';
import { ProductModel } from '../product/product.model';
import {UrlBackendProvider} from '../urlBackendProvider';
import { Observable } from 'rxjs/Observable';
import { ResponseHandler } from '../response/responseHandler';
import 'rxjs/add/operator/map';

@Injectable()
export class ReviewService{
   

    constructor(private router:Router, private http: Http, 
    private userContext:UserContext, private productModel:ProductModel, 
    private urlBackendProvider:UrlBackendProvider, private responseHandler:ResponseHandler){ }

  

    private processResponse(response:any){
        this.responseHandler.processResponse(response);
        this.userContext.fillContext(response);
    }

    
    addReview(reviewRequest:any):Observable<any>{
      let header=new Headers();
      header.append('Token',this.userContext.Token);
      return (this.http.post(this.urlBackendProvider.getBaseDir()+"/addReview", reviewRequest,{headers:header})
      .map(response => response.json())).map(reviewResponse => {
          this.processResponse(reviewResponse);
            return reviewResponse;
        });        
    }

    getReviewsByProduct(productId:string):Observable<any>{
        let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.get(this.urlBackendProvider.getBaseDir()+"/allReviewsByProduct/"+productId,{headers:header})
        .map(response => response.json())).map(reviewResponse => {
            return reviewResponse.Data;
        });        
    }
}