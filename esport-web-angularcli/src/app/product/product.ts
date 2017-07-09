import {ProductImage} from './productImage';
import {Field} from './field';
export class Product{
     Description:string; 
     ProductName:string;
     Price:Number;
     ProductId:string;
     ReviewAverage:Number;
     ImagePath:Array<ProductImage>=[];
     Fields:Array<Field>=[];
     Factory:string;
     BlackProduct:boolean;
     AvailableStock:number;

     constructor(prodId:string, description:string, productName:string, price:Number, 
     reviewAverage:Number, factory:string){
         this.ProductId=prodId;
         this.Description=description;
         this.ProductName=productName;
         this.Price=price;
         this.ReviewAverage=reviewAverage;
         this.Factory=factory;
     }
}