import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from './category.service';
import { CategoryModel } from './category.model';
import { CategoryRequest } from './categoryRequest';
import { ResponseHandler } from '../response/responseHandler';
@Component({
    selector: 'esport-app',
    templateUrl: './removeProductFromCategory.html'
})

export class RemoveProductFromCategoryComponent {
    isLoading:boolean=false;
    constructor(private categoryService: CategoryService, private router: Router,
    private categoryModel:CategoryModel, private responseHandler:ResponseHandler) {
    }

   removeProductFromCategory(categoryRequest: CategoryRequest) {
        this.categoryService.removeProductInCategory(categoryRequest).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading=false;
                if (response.Success) {
                    this.router.navigate(["/showCategories"]);
                }
            },error=> {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al eliminar producto de categoría");});
    }

   
}