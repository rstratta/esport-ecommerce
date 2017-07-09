import { Injectable } from '@angular/core';
@Injectable()
export class CategoryModel{
     CategoryId:string;
    Description:string;
    Eliminated:boolean;
    Products:Array<any>=[];
}