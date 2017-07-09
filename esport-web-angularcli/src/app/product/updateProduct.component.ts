import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from './product.service';
import { ProductModel } from './product.model';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './updateProduct.html'
})

export class UpdateProductComponent {
    isLoading: boolean = false;

    constructor(private productService: ProductService, private productModel: ProductModel,
        private router: Router, private responseHandler: ResponseHandler) {
    }


    updateProduct(productModel: ProductModel): void {
        this.isLoading = true;
        this.productService.updateProduct(productModel).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
                if (response.Success) {
                    this.router.navigate(["/showProducts"]);
                }
            }, error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Ocurrió un error actualizar producto. Reintente");
            }

        );
    }


}