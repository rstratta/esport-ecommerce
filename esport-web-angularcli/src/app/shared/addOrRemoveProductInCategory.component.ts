import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { CategoryRequest } from '../category/categoryRequest';
import { Product } from '../product/product';
import { CategoryService } from '../category/category.service';
import { ProductService } from '../product/product.service';
import { ResponseHandler } from '../response/responseHandler';
import { CategoryModel } from '../category/category.model';

@Component({
    selector: 'addOrRemoveProductFromCategory',
    templateUrl: './addOrRemoveProductInCategory.html',
})

export class AddOrRemoveProductInCategory implements OnChanges {
    @Input() private addProductView: boolean = false;
    @Input() private removeProductView: boolean = false;
    @Input() private loadingMessage: string;
    @Input() private categoryModel: CategoryModel;

    private loading: boolean = false;
    private productsToShow: Array<any> = [];


    @Output() addProductCategory: EventEmitter<CategoryRequest> = new EventEmitter<CategoryRequest>();
    @Output() removeProductCategory: EventEmitter<CategoryRequest> = new EventEmitter<CategoryRequest>();
    @Output() goToList: EventEmitter<CategoryRequest> = new EventEmitter<CategoryRequest>();

    constructor(private categoryService: CategoryService,
        private productService: ProductService, private responseHanlder: ResponseHandler) {

    }

    ngOnInit(): void {
        if (this.addProductView) {
            this.activeAddProductView();
        } else {
            this.activeRemoveProductView();
        }
    }
    ngOnChanges() {

    }



    activeAddProductView(): void {
        this.loading = true;
        this.loadingMessage = "Cargando productos";
        this.loadListModel();
    }

    loadListModel(): any {
        this.productsToShow = [];
        this.productService.getAllActiveFullProducts().subscribe(
            response => {
                for (let product of response.Data) {
                    if (product.CategoryId == null) {
                        this.productsToShow.push(product);
                    }
                }
                this.loading = false;
            },
            error => {
                this.loading = false;
                this.responseHanlder.buildBadResponse("Error al obtener productos");
            }
        );
    }

    activeRemoveProductView(): void {
        this.removeProductView = true;
        this.loading = true;
        this.loadingMessage = "Cargando productos";
        this.productsToShow = [];
        this.categoryService.getProductsByCategoryId(this.categoryModel.CategoryId).subscribe(
            response => {
                for (let product of response) {
                    this.productsToShow.push(product);
                }
                this.loading = false;
            },
            error => {
                this.loading = false;
                this.responseHanlder.buildBadResponse("Error al obtener productos por categoria");
            }

        );
    }

    onClickAddProductInCategory(product: Product): void {
        let categoryRequest = { CategoryId: this.categoryModel.CategoryId, ProductId: product.ProductId };
        this.addProductCategory.emit(categoryRequest);
        
    }

    onClickRemoveInCategory(product: Product): void {
        let categoryRequest = { CategoryId: this.categoryModel.CategoryId, ProductId: product.ProductId };
        this.removeProductCategory.emit(categoryRequest);
        
    }

    goToCategoryList() {
        this.goToList.emit();
    }

}



