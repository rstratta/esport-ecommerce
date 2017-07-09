import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router , ActivatedRoute} from '@angular/router';
import { MainPanelModel} from '../mainPanel/mainPanelModel';
import { UrlBackendProvider } from '../urlBackendProvider';
import { ResponseHandler } from '../response/responseHandler';
import { Observable } from "rxjs/Observable";
import { CategoryModel } from './category.model';
import 'rxjs/add/operator/map';

@Injectable()
export class CategoryService {


  constructor (
   private http: Http, private router:Router,
   private userContext:UserContext, 
   private urlBackendProvider:UrlBackendProvider, private responseHandler:ResponseHandler) {
    
  }

  

   addCategory(category:CategoryModel):Observable<any>{
      let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.post(this.urlBackendProvider.getBaseDir()+"/addCategory",category,{headers:header}).
        map(response => response.json())).map(categoryResponse => {
            return categoryResponse;
        });        
    }

   updateCategory(category:CategoryModel):Observable<any>{
      let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.put(this.urlBackendProvider.getBaseDir()+"/updateCategory",category,{headers:header}).
        map(response => response.json())).map(categoryResponse => {
            return categoryResponse;
        });        
    }

   removeCategory(category:CategoryModel):Observable<any>{
      let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.delete(this.urlBackendProvider.getBaseDir()+"/removeCategory",{headers:header, body:category}).
        map(response => response.json())).map(categoryResponse => {
            return categoryResponse.Data;
        });        
    }

  getAllActiveCategories(){
    return (this.http.get(this.urlBackendProvider.getBaseDir()+"/allActiveCategories").
    map(response => response.json())).map(categoryResponse => {
            return categoryResponse.Data;
        });        
    }

  getAllCategories():Observable<any>{
     let header=new Headers();
        header.append('Token',this.userContext.Token);
    return (this.http.get(this.urlBackendProvider.getBaseDir()+"/allCategories",{headers:header})
    .map(response => response.json())).map(categoryResponse => {
            return categoryResponse.Data;
        });        
    }

 

  getProductsByCategoryId(categoryId:string):Observable<any>{
    return (this.http.get(this.urlBackendProvider.getBaseDir()+"/productsByCategory/"+categoryId)
    .map(response => response.json())).map(categoryResponse => {
            return categoryResponse.Data;
        });        
    }

    addProductInCategory(categoryRequest:any):Observable<any>{
        let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.post(this.urlBackendProvider.getBaseDir()+"/addProductOnCategory",categoryRequest,{headers:header})
        .map(response => response.json())).map(categoryResponse => {
            return categoryResponse;
        });        
    }

    removeProductInCategory(categoryRequest:any):Observable<any>{
        let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.delete(this.urlBackendProvider.getBaseDir()+"/removeProductFromCategory",{headers:header , body:categoryRequest})
        .map(response => response.json())).map(categoryResponse => {
            return categoryResponse;
        }); 
    }
}