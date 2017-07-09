import { Component } from '@angular/core';
import { ProductService } from './product.service';
import { ProductModel } from './product.model';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';

@Component({
    selector: 'esport-app',
    templateUrl: './addProduct.html'
})

export class AddProductComponent {
    isLoading:boolean=false;

    constructor(private productService: ProductService,
        private responseHandler: ResponseHandler, private router: Router) {
        }

    addProduct(productModel:ProductModel): void {
        this.isLoading=true;
        this.productService.addProduct(productModel)
        .subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                this.router.navigate(["/mainPanel"]);
            }
            , error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al agregar producto.");});
    }

   
}