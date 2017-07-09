import { Component, Input, Output,EventEmitter, OnChanges} from '@angular/core';
import { CategoryModel } from '../category/category.model';

@Component({
    selector: 'category-form',
    templateUrl: './categoryForm.html'
})

export class SharedCategoryComponent implements OnChanges{
    @Input() categoryModel:CategoryModel;
    @Input() updateAction:boolean=false;
    @Output() addCategory: EventEmitter<CategoryModel> = new EventEmitter<CategoryModel>();
    @Output() updateCategory: EventEmitter<CategoryModel> = new EventEmitter<CategoryModel>();

    constructor(){
        this.categoryModel=new CategoryModel();
    }
    
    ngOnChanges(){

    }
   onClickAddCategory(): void {
        this.addCategory.emit(this.categoryModel);
    }

    onClickUpdateCategory(): void {
        this.updateCategory.emit(this.categoryModel);
    }

}