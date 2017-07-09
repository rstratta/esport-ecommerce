import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from './category.service';
import { CategoryModel } from './category.model';
import { CategoryRequest } from './categoryRequest';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './addProductInCategory.html'
})

export class AddProductInCategoryComponent {
    isLoading:boolean=false;
    constructor(private categoryService: CategoryService, 
    private router: Router, private categoryModel:CategoryModel, private responseHandler:ResponseHandler) {
    }

   addProductInCategory(categoryRequest: CategoryRequest) {
       this.isLoading=true;
        this.categoryService.addProductInCategory(categoryRequest).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading=false;
                if (response.Success) {
                    this.router.navigate(["/showCategories"]);
                }
            },error=> {
                this.responseHandler.buildBadResponse("Error al agregar producto a categoría");
                this.isLoading = false;});

    }

   
}