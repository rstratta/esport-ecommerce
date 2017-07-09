import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from './category.service';
import { CategoryModel } from './category.model';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './addCategory.html'
})

export class AddCategoryComponent {
    isLoading:boolean=false;

    constructor(private categoryService: CategoryService, private router: Router, private responseHandler:ResponseHandler) {
    }

    addCategory(categoryModel:CategoryModel): void {
        this.categoryService.addCategory(categoryModel).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading=false;
                if (response.Success) {
                    this.router.navigate(["/showCategories"]);
                }
            },error=> {
                this.responseHandler.buildBadResponse("Error al agregar categoría");
                this.isLoading = false;});
    }

   
}