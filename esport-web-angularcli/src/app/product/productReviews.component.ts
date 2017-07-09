import { Component } from '@angular/core';
import { UserContext } from '../user/userContext';
import { ReviewService } from '../review/review.service';
import { Product } from './product';
import {ProductModel} from './product.model';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';

@Component({
  selector: 'esport-app',
  templateUrl: './productReviewPanel.html'
})


export class ProductReviewComponent{
  isLoading:boolean=false;
    
  
  constructor(private productModel:ProductModel, private reviewService:ReviewService,
  private responseHandler:ResponseHandler, private router:Router){ }
  
  ngOnInit() {
    this.isLoading=true;
    this.reviewService.getReviewsByProduct(this.productModel.product.ProductId).subscribe(
        response=>{
            let reviewResponse=response;
             for (let review of reviewResponse){
                    this.productModel.reviews.push(review);
             }
             this.isLoading=false;
        },error=>{
          this.isLoading = false;
            this.responseHandler.buildBadResponse("Ocurrió un error al obtener review. Reintente");
        }

        );
  }

   
   
    
}