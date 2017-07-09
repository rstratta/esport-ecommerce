import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from './product.service';
import { ProductModel } from './product.model';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './addField.html'
})

export class AddFieldComponent {
    fieldTypes: Array<any> = [{ Type: "text", Description: "Texto" },
    { Type: "number", Description: "Númerico" },
    { Type: "date", Description: "Fecha" }];

   newFieldModel:any={};
   isLoading:boolean=false;
    
    constructor(private productService: ProductService, private productModel: ProductModel,
    private responseHandler:ResponseHandler, private router:Router) {
    }
    isATextField():boolean{
        return this.newFieldModel && this.newFieldModel.FieldType == "text";
    }
    isANumberField():boolean{
        return this.newFieldModel &&  this.newFieldModel.FieldType == "number";
    }
    isADateField():boolean{
        return this.newFieldModel &&  this.newFieldModel.FieldType == "date";
    }
    

    addFieldOnProduct(productModel: ProductModel): void {
        this.isLoading=true;
        this.productService.addFieldOnProduct(productModel)
        .subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                this.router.navigate(["/showProducts"]);
            }
            , error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al agregar campo en producto.");});
    }
    
    updateFieldOnProduct(productModel: ProductModel): void {
        this.isLoading=true;
        this.productService.updateProductField(productModel).subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                this.router.navigate(["/showProducts"]);
            }
            , error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al actualizar campo en producto.");});
    }

    addNewFieldOnProduct() {
        this.productModel.FieldName=this.newFieldModel.FieldName;
        this.productModel.FieldValue=this.newFieldModel.FieldValue;
        this.productModel.FieldType=this.newFieldModel.FieldType;
        this.isLoading=true;
        this.productService.addFieldOnProduct(this.productModel).subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                this.router.navigate(["/showProducts"]);
            }
            , error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al agregar campo en producto.");});
    }

}