import {Product} from './product';


export class ProductModel{
    product:Product;
    reviews:any=[];
    ProductId:string;
    ProductName:string;
    Description:string;
    Factory:string;
    Price:string;
    Images:Array<any>=[];
    Eliminated:boolean;
    FieldName:string;
    FieldValue:any;
    FieldType:string;
    Fields:Array<any>=[];
    ReviewAverage:number=0;
    Quantity:number=1;
    AvailableStock:number=0;
}