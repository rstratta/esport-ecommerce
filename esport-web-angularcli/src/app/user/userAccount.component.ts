import { Component, Output } from '@angular/core';
import {UserContext} from '../user/userContext';
import {NgModel} from '@angular/forms';
import {UserModel} from './user.model';
import {UserService} from './user.service';
import { ResponseHandler } from '../response/responseHandler';
import { Router } from '@angular/router';
@Component({
  selector: 'esport-app',
  templateUrl: './userAccount.html',
})


export class UserAccountComponent  {
  model:any={};
  currentUserModel:UserModel;
  isLoading:boolean=false;
  
  
  constructor( private userSrvice:UserService,private userContext:UserContext, 
  private responseHandler:ResponseHandler, private router:Router){
      this.currentUserModel=new UserModel();
      this.fillUserModel();
  }

  fillUserModel():void{
      this.currentUserModel.UserId=this.userContext.UserId;
      this.currentUserModel.Address=this.userContext.Address;
      this.currentUserModel.EMail=this.userContext.Mail;
      this.currentUserModel.Phone=this.userContext.Phone;
      this.currentUserModel.UserLastName=this.userContext.UserLastName;
      this.currentUserModel.UserName=this.userContext.UserName;
  }

  updateUser(userModel:UserModel){
    this.userSrvice.updateUser(userModel).subscribe(response => {
      this.responseHandler.processResponse(response);
      this.isLoading = false;
      this.router.navigate(["/mainPanel"]);
    }, error => {
      this.isLoading = false;
      this.responseHandler.buildBadResponse("Error al obtener usuarios");});
  }


  changePassword():void{
    this.fillUserModel();
    this.currentUserModel.Password=this.model.Password;
    this.currentUserModel.NewPassword=this.model.NewPassword;
    this.userSrvice.updatePassword(this.currentUserModel);
  }
}
