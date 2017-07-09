import { Product } from '../product/product';
import { CategoryModel } from '../category/category.model';
export class MainPanelModel{
    activeCategories:Array<CategoryModel>=[];
    allCategories:Array<CategoryModel>=[];
    activeProducts:Array<Product>=[];
    isLoading:boolean;

    addProduct(prod:any){
        let product:Product=new Product(prod.ProductId, prod.Description, 
        prod.ProductName, prod.Price, prod.ReviewAverage, prod.Factory);
        product.Fields=[];
        product.AvailableStock=prod.AvailableStock;
        product.BlackProduct=prod.BlackProduct;
        for (let image of prod.ImagePath){
            product.ImagePath.push(image);
        }
        if(prod.Fields){
            for (let field of prod.Fields){
                product.Fields.push(field);
            }
        }
        this.activeProducts.push(product);
    }
}