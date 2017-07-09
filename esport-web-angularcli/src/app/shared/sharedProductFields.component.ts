import { Component, Input, Output,EventEmitter, OnChanges} from '@angular/core';
import { ProductModel } from '../product/product.model';

@Component({
    selector: 'product-field-table',
    templateUrl: './productFieldTable.html'
})

export class SharedProductFieldComponent implements OnChanges{
    @Input() productModel:ProductModel;
    @Input() removeAction:boolean=false;
    @Output() addProductField: EventEmitter<ProductModel> = new EventEmitter<ProductModel>();
    @Output() updateProductField: EventEmitter<ProductModel> = new EventEmitter<ProductModel>();
    @Output() removeProductField: EventEmitter<ProductModel> = new EventEmitter<ProductModel>();
    allFields:Array<any>=[];
    originalFields:Array<any>=[];

    constructor(){
        
    }
    
    ngOnInit(){
        
        if(this.removeAction){
            for(let field of this.productModel.Fields){
                if(field.FieldValue != null){
                     this.allFields.push(field);
                }
            }
        }else{
            this.allFields=this.productModel.Fields;
            this.originalFields=this.allFields;
        }        
    }
    ngOnChanges(){

    }
   onClickAddOrUpdateProductField(field:any): void {
       for(let originalField of this.originalFields){
           if(originalField.FieldName == field.FieldName){
               if(originalField.FieldValue == null){
                   this.addFieldOnProduct(field);
               }else{
                   this.updateFieldOnProduct(field);
               }
           }
       }
        this.fillProductModel(field);
        this.addProductField.emit(this.productModel);
    }

    addFieldOnProduct(field:any): void {
      this.fillProductModel(field);
        this.addProductField.emit(this.productModel);
    }
    updateFieldOnProduct(field:any): void {
        this.fillProductModel(field);
        this.updateProductField.emit(this.productModel);
    }

    onClickRemoveProductField(field:any): void {
        this.fillProductModel(field);
        this.removeProductField.emit(this.productModel);
    }

    fillProductModel(field:any){
        this.productModel.FieldName=field.FieldName;
        this.productModel.FieldValue=field.FieldValue;
        this.productModel.FieldType=field.FieldType;
    }
}