import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { ProductModel } from '../product/product.model';

@Component({
    selector: 'product-form',
    templateUrl: './productForm.html'
})

export class SharedProductComponent  {
    @Input() productModel: ProductModel;
    @Input() updateAction: boolean = false;
    @Output() addProduct: EventEmitter<ProductModel> = new EventEmitter<ProductModel>();
    @Output() updateProduct: EventEmitter<ProductModel> = new EventEmitter<ProductModel>();
    @Input() imageLoaded:Array<any>;
    internalId:number=0;
    constructor() {
        this.productModel = new ProductModel();
        this.imageLoaded=[];
    }

    ngOnInit() {
        if(this.productModel && this.productModel.Images){
            for(let image of this.productModel.Images){
                this.imageLoaded.push(image);
            }
        }
    }


    addImage(event: any) {
        let files = event.target.files;
        for(let file of files){
            if (files && file) {
            var reader = new FileReader();
            reader.onload = this._handleReaderLoaded.bind(this);
            reader.readAsBinaryString(file);
            
             }
        }
    }

    _handleReaderLoaded(readerEvt:any) {
        var binaryString = readerEvt.target.result;
        btoa(binaryString);
        this.imageLoaded.push({Id:this.internalId, Content:btoa(binaryString)});
        this.internalId++;
    }

    removeImage(imageToRemove:any){
        let newImageLoaded:Array<any>=[];
        for (let image of this.imageLoaded){
            if(image.Id!=imageToRemove.Id){
                newImageLoaded.push(image);
            }
        }
        this.imageLoaded=newImageLoaded;
    }

    onClickAddProduct(): void {
        this.loadImageOnModel();
        this.addProduct.emit(this.productModel);
    }

    onClickUpdateProduct(): void {
        this.loadImageOnModel();
        this.updateProduct.emit(this.productModel);
    }

    loadImageOnModel(){
        this.productModel.Images=[];
        for (let image of this.imageLoaded){
            this.productModel.Images.push({Content:image.Content});
        }
    }

}