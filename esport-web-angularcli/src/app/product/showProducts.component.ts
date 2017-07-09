import { Component } from '@angular/core';
import { ProductService } from './product.service';
import { ProductModel } from './product.model';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';

@Component({
    selector: 'esport-app',
    templateUrl: './showProducts.html'
})

export class ShowProductsComponent {
    private products: Array<any> = [];
    isLoading:boolean=false;

    constructor(private productService: ProductService, private router: Router
    , private productModel:ProductModel, private responseHandler:ResponseHandler) {
    }

   
    ngOnInit() {
        this.loadProducts();
    }

   loadProducts(){
       this.isLoading=true;
       this.productService.getAllFullProducts()
        .subscribe(response => {
            this.products = response.Data;
             this.isLoading=false;
             this.router.navigate(["/showProducts"]);
            },error=> {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al obtener producto.");});
   }
    updateModel(product: any, url:string): void {
        this.productModel.Images=[];
        this.productModel.Fields=[];
        this.productModel.ProductId=product.ProductId;
        this.productModel.ProductName=product.ProductName;
        this.productModel.Description=product.Description;
        this.productModel.Factory=product.Factory;
        this.productModel.Price=product.Price;
        this.productModel.Eliminated=product.Eliminated;
        for(let image of product.Images){
            this.productModel.Images.push(image);
        }
        for(let field of product.Fields){
            this.productModel.Fields.push(field);
        }
        this.router.navigate([url]);
    }

    removeProduct(product: ProductModel): void {
        this.productService.removeProduct(product).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.loadProducts();
                this.isLoading=false;
            },error=> {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al eliminar producto.");});
    }

    restoreProduct(product: ProductModel): void {
        product.Eliminated=false;
        this.productService.updateProduct(product).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.loadProducts();
                this.isLoading=false;
            },error=> {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al restaurar producto.");});
    }
}