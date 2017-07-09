import { Component } from '@angular/core';
import { ProductService } from './product.service';
import { ProductModel } from './product.model';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';

@Component({
    selector: 'esport-app',
    templateUrl: './removeProductField.html'
})

export class RemoveProductFieldComponent {
    isLoading:boolean=false;

   
    
    constructor(private productService: ProductService, 
    private productModel: ProductModel, private responseHandler:ResponseHandler,
    private router:Router) {
    }
    
    removeProductField(productModel: ProductModel): void {
        this.productService.removeProductField(productModel).
        subscribe(response => {
                this.isLoading=false;
                this.responseHandler.processResponse(response);
                this.router.navigate(["/showProducts"]);
            },error=> {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al obtener producto.");});
    }
}