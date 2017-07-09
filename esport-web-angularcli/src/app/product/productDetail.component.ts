import { Component } from '@angular/core';
import { ProductModel } from './product.model';
import { CartService } from '../cart/cart.service';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';
import { UserContext } from '../user/userContext';

@Component({
    selector: 'esport-app',
    templateUrl: './productDetail.html'
})

export class ProductDetailComponent {
    currentImage: any;
    isLoading: boolean = false;
    inputQuantity:number=1;

    constructor(private productModel: ProductModel, private cartService: CartService,
        private responseHandler: ResponseHandler, private router: Router,
        private userContext:UserContext) {
        if (this.productModel.Images.length)
            this.currentImage = productModel.Images[0];
    }

    updateCurrentImage(image: any) {
        this.currentImage = image;
    }

    addProductToCart() {
        this.isLoading = true;
        this.cartService.addItem(this.productModel.ProductId, this.inputQuantity)
            .subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                this.responseHandler.hideMessage();
                this.router.navigate(["/mainPanel"]);
            }
            , error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al agregar producto al carrito.");});
    }
}