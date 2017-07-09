import { Component } from '@angular/core';
import { ReviewService } from './review.service';
import {ReviewModel} from './reviewModel';
import {ProductModel} from '../product/product.model';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';

@Component({
    selector: 'esport-app',
    templateUrl: './reviewPanel.html'
})



export class ReviewComponent{
    isLoading:boolean=false;
  
  constructor(private reviewModel:ReviewModel,private  productModel:ProductModel,
   private reviewService:ReviewService, private responseHandler:ResponseHandler, private router:Router){}

 ngOnInit() {
    this.reviewModel.ReviewDescription=null;
    this.reviewModel.ReviewPoints=0;
  }
  

    addReview(){
        let reviewRequest={
            CartItemId:this.reviewModel.CartItemId,
            Description:this.reviewModel.ReviewDescription,
            Points:this.reviewModel.ReviewPoints,
            ProductId:this.reviewModel.ProductId
        };
        this.isLoading=true;
        this.reviewService.addReview(reviewRequest).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
                if (response.Success) {
                    this.router.navigate(["/mainPanel"]);
                }
            }, error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al agregar review");});
    }
}