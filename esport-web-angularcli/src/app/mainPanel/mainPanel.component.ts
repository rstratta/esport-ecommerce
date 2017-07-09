import { Component } from '@angular/core';
import { MainPanelModel } from './mainPanelModel';
import { CategoryService } from '../category/category.service';
import { UserContext } from '../user/userContext';
import { ProductService } from '../product/product.service';
import { CartService } from '../cart/cart.service';
import { CartHistoryModel } from '../cart/cartHistoryModel';
import {ProductModel} from '../product/product.model';
import {UrlBackendProvider} from '../urlBackendProvider';
import { ResponseHandler } from '../response/responseHandler';

@Component({
  selector: 'esport-app',
  templateUrl: './mainPanel.html'  
})


export class MainPanelComponent   {
   filter:any={};
   filterTypes: Array<any> = [{ Id: "description", Description: "Descripción" },
   { Id: "productName", Description: "Nombre prod" },
   { Id: "factory", Description: "Fabricante" },
   { Id: "price", Description: "Precio" }];

   filterTypeOp: Array<any> = [{ Id: "asc", Operation: "Ascendente" },
   { Id: "desc", Operation: "Descendente" }];

   noImagePath:string="../images/noImage.jpg";
  
  constructor (private userContext:UserContext, private mainPanelModel:MainPanelModel,
  private productModel:ProductModel,private cartService:CartService,
   private categoryService:CategoryService, 
  private productService:ProductService, private urlBackendProvider:UrlBackendProvider,
  private responseHandler:ResponseHandler) {}

  ngOnInit() {
    this.mainPanelModel.isLoading=true;
    this.urlBackendProvider.config().subscribe((response) => {
      if (response.serverIp) {
        this.getAllActiveCategories();
        this.getAllActiveProducts();
      }
    });
    
  }

  
  
  getProductsByCategoryId(categoryId:string){
     this.categoryService.getProductsByCategoryId(categoryId).subscribe(
        response=>{
          this.processProductResponse(response);
         },
         error=>{
            this.responseHandler.buildBadResponse("Error al obtener productos por categoría");
         }
      );
  }
  
  getAllActiveCategories(){
      this.categoryService.getAllActiveCategories().subscribe(
        response=>{
          this.processActiveCategoriesResponse(response);
         },
         error=>{
            this.responseHandler.buildBadResponse("Error al obtener categorías");
         }
      );
  }

  getAllActiveProducts(){
    if(this.userContext.userIsLoged()){
      this.getAllFullProducts();
    }else{
      this.getAllSimpleProducts();
    }
  }
 
  getAllFullProducts():void{
    this.productService.getAllActiveFullProducts().subscribe(
        response=>{
          this.processProductResponse(response.Data);
          this.mainPanelModel.isLoading=false;
         },
         error=>{
            this.responseHandler.buildBadResponse("Error al obtener categorías");
            this.mainPanelModel.isLoading = false;
         }
      );
  }

  getAllSimpleProducts():void{
    this.productService.getAllActiveProducts().subscribe(
        response=>{
          this.processProductResponse(response.Data);
          this.mainPanelModel.isLoading=false;
         },
         error=>{
            this.responseHandler.buildBadResponse("Error al obtener categorías");
            this.mainPanelModel.isLoading = false;
         }
      );
  }
  addItemInCart(productId:string){
    this.mainPanelModel.isLoading=false;
    this.cartService.addItem(productId,1).subscribe(
        response=>{
          this.responseHandler.processResponse(response);
          this.mainPanelModel.isLoading=false;
         },
         error=>{
            this.responseHandler.buildBadResponse("Error al obtener categorías");
            this.mainPanelModel.isLoading = false;
         }
      );
  }

  showReviews(product:any){
    this.productModel.product=product;
    this.productModel.reviews=[];
  }

  private processActiveCategoriesResponse(categoryResponse:any){
    this.mainPanelModel.activeCategories=[];
      for (let category of categoryResponse){
            this.mainPanelModel.activeCategories.push(category);
        }
   }

  private processProductResponse(products:any){
      this.mainPanelModel.activeProducts=[];
      for (let product of products){
            this.mainPanelModel.activeProducts.push(product);
        }
  }

  updateModel(product:any){
    this.productModel.ProductId=product.ProductId;
    this.productModel.Description=product.Description;
    this.productModel.Factory=product.Factory;
    this.productModel.Price=product.Price;
    this.productModel.ProductName=product.ProductName;
    this.productModel.Fields=product.Fields;
    this.productModel.Images=product.Images;
    this.productModel.ReviewAverage=product.ReviewAverage;
    this.productModel.AvailableStock=product.AvailableStock;
  }

  applyFilter():void{
    let filters:Array<any>=[];
    if(this.filter.Description){
      filters.push({fieldName:'description', fieldValue:this.filter.Description});
    }
    if(this.filter.ProductName){
      filters.push({fieldName:'productName', fieldValue:this.filter.ProductName});
    }
    if(this.filter.Factory){
      filters.push({fieldName:'factory', fieldValue:this.filter.Factory});
    }
    if(this.filter.Price){
      filters.push({fieldName:'price', fieldValue:this.filter.Price});
    }
    if(this.filter.OrderByFilterName){
      filters.push({fieldName:'orderByFilter', fieldValue:this.filter.OrderByFilterName});
      if(this.filter.OrderByOperation){
        filters.push({fieldName:'orderByOperation', fieldValue:this.filter.OrderByOperation});
      }else{
        filters.push({fieldName:'orderByOperation', fieldValue:'asc'});
      }
    }
    let filterRequest:any={Filters:filters};
    this.productService.getProductsByFilter(filterRequest).subscribe(
        response=>{
          this.processProductResponse(response.Data);
          this.mainPanelModel.isLoading=false;
         },
         error=>{
            this.responseHandler.buildBadResponse("Error al obtener productos");
            this.mainPanelModel.isLoading = false;
         }
      );
  }
}
