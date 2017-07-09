import { Component, Input, Output,EventEmitter, OnChanges} from '@angular/core';
import {CartItem} from '../cart/cart';
import {CartItemRequest} from './cartItemRequest';

@Component({
    selector: 'cartItem-view',
    templateUrl: './cartItem.html'
})


export class CartItemComponent implements OnChanges{
    @Input()  cartItems:Array<CartItem>;
    @Input()  isACurrentCartView:boolean=true;
    cartModel:any={inputQuantity:1};
    @Output() addItem: EventEmitter<CartItemRequest> = new EventEmitter<CartItemRequest>();
    @Output() removeItem: EventEmitter<CartItemRequest> = new EventEmitter<CartItemRequest>();
    @Output() removeAllItems: EventEmitter<CartItemRequest> = new EventEmitter<CartItemRequest>();
    
    constructor(){
        
    }

    ngOnChanges(){

    }

    onClickAddItem(prodId:string,quantity:number): void {
        let itemRequest:CartItemRequest={productId:prodId, quantity:quantity};
        this.addItem.emit(itemRequest);
    }

    onClickRemoveItem(prodId:string, quantity:number): void {
        let itemRequest:CartItemRequest={productId:prodId, quantity:quantity};
        this.removeItem.emit(itemRequest);
    }

    onClickRemoveAllItem(prodId:string, inputQuantity:number): void {
        let itemRequest:CartItemRequest={productId:prodId, quantity:inputQuantity};
        this.removeAllItems.emit(itemRequest);
    }
}