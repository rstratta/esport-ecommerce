import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router , ActivatedRoute} from '@angular/router';
import {UrlBackendProvider} from '../urlBackendProvider';
import { Observable } from 'rxjs/Observable';
import { ResponseHandler } from '../response/responseHandler';
import 'rxjs/add/operator/map';

export class LoginUserRequest{
  userId:string;
  userPassword:string;
}

@Injectable()
export class LoginService {
  

  constructor (private http: Http, private router:Router, 
  private userContext:UserContext, private urlBackendProvider:UrlBackendProvider
  , private responseHandler:ResponseHandler) {}

  private processResponse(response:any){
    if(!response.Success){
      this.responseHandler.buildBadResponse(response.Message);
    }else{
      this.responseHandler.hideMessage();
    }
  }
  
 
  login(userId:string, userPassword:string):Observable<any>{
    var loginRequest:LoginUserRequest=new LoginUserRequest();
    loginRequest.userId=userId;
    loginRequest.userPassword=userPassword;
    return (this.http.post(this.urlBackendProvider.getBaseDir()+"/loginUser", loginRequest).
            map(response => response.json())).map(loginResponse => {
              this.processResponse(loginResponse);
                return loginResponse;
            });
    }

  signUpUser(userRequest:any):Observable<any>{
    return (this.http.post(this.urlBackendProvider.getBaseDir()+"/signUp", userRequest).
            map(response => response.json())).map(loginResponse => {
              this.processResponse(loginResponse);
                return loginResponse;
            });
    }
  

  logout(token:string){
      let header=new Headers();
      header.append('Token',token);
      this.http.get(this.urlBackendProvider.getBaseDir()+"/logoutUser", {headers:header}).subscribe(
      response=>{
        this.userContext.cleanContext();
      },error=>{
      }
      );
      
  }
}