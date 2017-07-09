import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router, ActivatedRoute } from '@angular/router';
import { MainPanelModel } from '../mainPanel/mainPanelModel';
import { UrlBackendProvider } from '../urlBackendProvider';
import { ResponseHandler } from '../response/responseHandler';
import { ProductModel } from './product.model';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';
@Injectable()
export class ProductService {



    constructor(
        private http: Http, private router: Router,
        private userContext: UserContext,
        private urlBackendProvider: UrlBackendProvider, private responseHandler: ResponseHandler) { }



    getAllActiveProducts(): Observable<any> {
        return (this.http.get(this.urlBackendProvider.getBaseDir() + "/allSimpleProduct").
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    getAllActiveFullProducts(): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.get(this.urlBackendProvider.getBaseDir() + "/allActiveFullProduct", { headers: header }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    getAllFullProducts(): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.get(this.urlBackendProvider.getBaseDir() + "/allFullProduct", { headers: header }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    addFieldOnProduct(product: ProductModel): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.post(this.urlBackendProvider.getBaseDir() + "/addFieldOnProduct", product, { headers: header }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    removeProductField(product: ProductModel): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.delete(this.urlBackendProvider.getBaseDir() + "/removeFieldOnProduct", { headers: header, body: product }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    updateProductField(product: ProductModel): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.put(this.urlBackendProvider.getBaseDir() + "/updateFieldOnProduct", product, { headers: header }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    addProduct(product: ProductModel): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.post(this.urlBackendProvider.getBaseDir() + "/addProduct", product, { headers: header }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    removeProduct(product: ProductModel): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.delete(this.urlBackendProvider.getBaseDir() + "/removeProduct", { headers: header, body: product }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    updateProduct(product: ProductModel): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.put(this.urlBackendProvider.getBaseDir() + "/updateProduct", product, { headers: header }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }

    getProductsByFilter(filters: any): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.post(this.urlBackendProvider.getBaseDir() + "/simpleProductByFilter", filters, { headers: header }).
            map(response => response.json())).map(productResponse => {
                return productResponse;
            });
    }


}