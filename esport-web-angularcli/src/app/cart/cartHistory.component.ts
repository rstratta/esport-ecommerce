import { Component } from '@angular/core';
import { CartService } from './cart.service';
import {CartHistoryModel} from './cartHistoryModel';

@Component({
  selector: 'esport-app',
  templateUrl: './cartHistory.html'
})
export class CartHistoryComponent{
    
    constructor(private cartService:CartService, private cartHistoryModel:CartHistoryModel){}

    ngOnInit() {
        this.cartService.getAllCartsByUser();
    }

   
}