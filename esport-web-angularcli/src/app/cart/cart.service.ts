import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router, ActivatedRoute } from '@angular/router';
import { CartHistoryModel } from './cartHistoryModel';
import { UrlBackendProvider } from '../urlBackendProvider';
import { ResponseHandler } from '../response/responseHandler';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';

export class CartRequest {
  Productid: string;
  quantity: Number;
  deliveryAddress: string = null;
  deliveryPhone: string = null;
}


@Injectable()
export class CartService {




  constructor(private http: Http, private router: Router,
    private cartHistoryModel: CartHistoryModel, private userContext: UserContext,
    private urlBackendProvider: UrlBackendProvider, private responseHandler: ResponseHandler) { }


  private processResponse(response: any) {
    this.responseHandler.processResponse(response)
    this.userContext.fillContext(response);
  }

  addItem(productId: string, quantity: Number): Observable<any> {
    var cartRequest: CartRequest = new CartRequest();
    cartRequest.Productid = productId;
    cartRequest.quantity = quantity;
    let header = new Headers();
    header.append('Token', this.userContext.Token);
    return (this.http.post(this.urlBackendProvider.getBaseDir() + "/addItem", cartRequest, { headers: header })
      .map(response => response.json())).map(cartResponse => {
        this.processResponse(cartResponse);
        return cartResponse;
      });
  }




  removeItem(productId: string, quantity: Number): Observable<any> {
    var cartRequest: CartRequest = new CartRequest();
    cartRequest.Productid = productId;
    cartRequest.quantity = quantity;
    let header = new Headers();
    header.append('Token', this.userContext.Token);
    return (this.http.post(this.urlBackendProvider.getBaseDir() + "/removeItem", cartRequest, { headers: header }).map(response => response.json())).map(cartResponse => {
        this.processResponse(cartResponse);
        return cartResponse;
      });
  }

  cancelCart(): Observable<any> {
    let header = new Headers();
    header.append('Token', this.userContext.Token);
    return (this.http.get(this.urlBackendProvider.getBaseDir() + "/cancelCart", { headers: header }).map(response => response.json())).map(cartResponse => {
        this.processResponse(cartResponse);
        return cartResponse;
      });
  }

  confirmCart(deliveryAddress: string, deliveryPhone: string): Observable<any> {
    var cartRequest: CartRequest = new CartRequest();
    if (deliveryAddress != 'undefined')
      cartRequest.deliveryAddress = deliveryAddress;
    if (deliveryPhone != 'undefined')
      cartRequest.deliveryPhone = deliveryPhone;
    let header = new Headers();
    header.append('Token', this.userContext.Token);
    return (this.http.post(this.urlBackendProvider.getBaseDir() + "/confirmCart", cartRequest, { headers: header }).map(response => response.json())).map(cartResponse => {
        this.processResponse(cartResponse);
        return cartResponse;
      });
  }

  getAllCartsByUser() {
    let header = new Headers();
    header.append('Token', this.userContext.Token);
    this.http.get(this.urlBackendProvider.getBaseDir() + "/allCartsByUser", { headers: header }).subscribe(
      response => {
        let cartResponse = response.json();
        this.cartHistoryModel.carts = cartResponse.Data;
        this.responseHandler.hideMessage();
      }, error => {
        this.responseHandler.buildBadResponse("Ocurrió un error al obtener historial de  carritos. Reintente");
        
      }

    );
  }
}