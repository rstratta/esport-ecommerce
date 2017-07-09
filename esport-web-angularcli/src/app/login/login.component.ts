import { Component, Output } from '@angular/core';
import {UserContext} from '../user/userContext';
import {LoginService} from './login.service';
import {NgModel} from '@angular/forms';
import {UserModel} from '../user/user.model';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';

@Component({
  selector: 'esport-app',
  moduleId: module.id,
  templateUrl: './login.html',
})


export class LoginComponent  {
  model:any={};
  localTitle:string="Crea tu cuenta";
  isLoading:boolean=false;
  
  
  constructor( private loginService:LoginService,private userContext:UserContext, 
  private responseHandler:ResponseHandler, private router:Router){}


  loginUser(){
    this.isLoading=true;
    this.loginService.login(this.model.userId, this.model.userPassword).subscribe(
      response=>{
        this.userContext.fillContext(response);
        this.isLoading=false;
        this.router.navigate(["/home"]);
      },error=>{
          this.responseHandler.buildBadResponse("Ocurrió un error al conectar con servicio de login. Reintente");
          this.isLoading=false;
      }
    );
  }

  signUpUser(userModel:UserModel):void{
    userModel.RoleId='client';
    this.loginService.signUpUser(userModel).subscribe(
      response=>{
        this.userContext.fillContext(response);
        this.isLoading=false;
        this.router.navigate(["/home"]);
      },error=>{
          this.responseHandler.buildBadResponse("Ocurrió un error al conectar con servicio de login. Reintente");
          this.isLoading=false;
      }
    );
  }

  logoutUser():void{
      this.loginService.logout(this.userContext.Token);
  }
}
