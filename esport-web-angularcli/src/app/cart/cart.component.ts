import { Component } from '@angular/core';
import { UserContext } from '../user/userContext';
import { CartService } from './cart.service';
import { CartHistoryModel } from './cartHistoryModel';
import { CartItemRequest } from '../shared/cartItemRequest';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';


@Component({
    selector: 'esport-app',
    templateUrl: './cart.html'
})


export class CartComponent {
    cartModel: any = {};
    isLoading: boolean = false;

    constructor(private userContext: UserContext, private cartService: CartService,
        private responseHandler: ResponseHandler, private router: Router) { }


    verifyQuantity(productId: string, inputQuantity: number) {
        for (let item of this.userContext.currentCart.itemsDTO) {
            if (item.ProductId == productId && item.Quantity != inputQuantity) {
                return inputQuantity;
            }
        }
        return 1;
    }

    addItem(cartItemRequest: CartItemRequest) {
        let quantity: Number = this.verifyQuantity(cartItemRequest.productId, cartItemRequest.quantity);
        this.isLoading = true;
        this.cartService.addItem(cartItemRequest.productId, quantity).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
            }, error => this.responseHandler.buildBadResponse("Error al agregar item al carrito"));
    }

    removeItem(cartItemRequest: CartItemRequest) {
        let quantity: Number = this.verifyQuantity(cartItemRequest.productId, cartItemRequest.quantity);
        this.cartService.removeItem(cartItemRequest.productId, quantity).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
            }, error =>{
                this.isLoading = false;
                 this.responseHandler.buildBadResponse("Error al remover item del carrito");});
    }

    removeAllItem(cartItemRequest: CartItemRequest) {
        this.cartService.removeItem(cartItemRequest.productId, cartItemRequest.quantity).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
            }, error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al remover item del carrito");});
    }


    cancelCart() {
        this.cartService.cancelCart().subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
                if (response.Success) {
                    this.router.navigate(["/mainPanel"]);
                }
            }, error => {
                this.responseHandler.buildBadResponse("Error al cancelar carrito");
                this.isLoading = false;
            });

    }

    confirmCart() {
        this.cartService.confirmCart(this.cartModel.deliveryAddress, this.cartModel.deliveryPhone).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
                if (response.Success) {
                    this.router.navigate(["/mainPanel"]);
                }
            }, error => {
                this.responseHandler.buildBadResponse("Error al cancelar carrito");
                this.isLoading = false;
            });
    }
}