import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router } from '@angular/router';
import {UrlBackendProvider} from '../urlBackendProvider';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';

@Injectable()
export class RoleService{

    constructor(private http:Http, private router:Router, 
    private urlBackendProvider:UrlBackendProvider,
     private userContext:UserContext){}

    

    getAllRoles():Observable<any>{
      let header=new Headers();
      header.append('Token',this.userContext.Token);
      return (this.http.get(this.urlBackendProvider.getBaseDir()+"/allRoles",
      {headers:header}).map(response => response.json())).map(roleResponse => {
            return roleResponse.Data;
        });        
    }

    getAllActiveRoles():Observable<any>{
      let header=new Headers();
      header.append('Token',this.userContext.Token);
      return (this.http.get(this.urlBackendProvider.getBaseDir()+"/allActiveRoles",
      {headers:header}).map(response => response.json())).map(roleResponse => {
            return roleResponse.Data;
        });        
    }
    
    addRole(roleRequest:any):Observable<any>{
        let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.post(this.urlBackendProvider.getBaseDir()+"/addRole",roleRequest,{headers:header}).map(response => response.json())).map(roleResponse => {
            return roleResponse;
        });   
    }

    updateRole(roleRequest:any):Observable<any>{
        let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.put(this.urlBackendProvider.getBaseDir()+"/editRole",roleRequest,{headers:header})
        .map(response => response.json())).map(roleResponse => {
            return roleResponse;
        });  
    }

    removeRole(roleRequest:any):Observable<any>{
        let header=new Headers();
        header.append('Token',this.userContext.Token);
        return (this.http.delete(this.urlBackendProvider.getBaseDir()+"/removeRole",{headers:header,body:roleRequest})
        .map(response => response.json())).map(roleResponse => {
            return roleResponse;
        });  
    }
}