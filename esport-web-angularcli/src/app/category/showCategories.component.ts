import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from './category.service';
import { CategoryModel } from './category.model';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './showCategories.html'
})

export class ShowCategoriesComponent {
    isLoading: boolean = false;
    private categories: Array<any> = [];
    

    constructor(private categoryService: CategoryService, private router: Router
    , private categoryModel:CategoryModel, private responseHandler:ResponseHandler) {
    }

   
    ngOnInit() {
        this.isLoading=true;
        this.categoryService.getAllCategories()
        .subscribe(response => {this.categories = response;
        this.isLoading=false;}); 
    }

   
    updateModel(category: any, url:string): void {
        this.categoryModel.CategoryId=category.CategoryId;
        this.categoryModel.Description=category.Description;
        this.categoryModel.Eliminated=category.Eliminated;
        this.router.navigate([url]);
    }

    removeCategory(category: CategoryModel): void {
        this.isLoading=true;
        this.categoryService.removeCategory(category) .subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                category.Eliminated=true;
            }
            , error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al eliminar categoría.");});
    }

    restoreCategory(category: CategoryModel): void {
        this.isLoading=true;
        this.categoryService.updateCategory(category) .subscribe(response => {
            this.isLoading = false;
                this.responseHandler.processResponse(response);
                category.Eliminated=false;
            }
            , error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al restaurar categoría.");});
    }

}