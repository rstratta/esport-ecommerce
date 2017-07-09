import { Component } from '@angular/core';
import { ReviewService } from './review.service';
import { ReviewModel } from './reviewModel';
import {ProductModel} from '../product/product.model';
import {UserContext} from '../user/userContext';
@Component({
  selector: 'esport-app',
  templateUrl: './pendingReviewPanel.html'
})


export class PendingReviewComponent{
   
  constructor(private reviewModel:ReviewModel, private productModel:ProductModel, private userContext:UserContext){ }

   showReviewForm(pendReview:any){
        this.reviewModel.CartItemId=pendReview.CartItemId;
        this.reviewModel.ItemDescription=pendReview.ItemDescription;
        this.reviewModel.ProductId=pendReview.ProductId;
    }

    
}