import { Component } from '@angular/core';
import { CategoryService } from './category.service';
import { CategoryModel } from './category.model';
import { Router } from '@angular/router';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './updateCategory.html'
})

export class UpdateCategoryComponent {
    isLoading:boolean=false;
    constructor(private categoryService: CategoryService, private router:Router ,
    private categoryModel:CategoryModel, private responseHandler:ResponseHandler) {
    }

   
    
    updateCategory(categoryModel:CategoryModel): void {
        this.isLoading = true;
        this.categoryService.updateCategory(categoryModel)
        .subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                this.router.navigate(["/showCategories"]);
            }
            , error => {this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al actualizar categoría.");});
    }

   
}