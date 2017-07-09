export class CartItem{
    itemId:string;
    productDescription:string;
    Quantity:Number;
    itemAmount:Number;
    unitAmount:Number;
    ProductId:string;
    InputQuantity:number=1;
}

export class Cart{
    cartId:string;
    opendate:string;
    total:Number;
    itemsDTO:Array<CartItem>=[];
}