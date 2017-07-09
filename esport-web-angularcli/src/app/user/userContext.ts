import { Injectable } from '@angular/core';
import {Cart} from '../cart/cart';
import {CartItem} from '../cart/cart';
import { RoleModel } from '../role/role.model';

export class PendingReview{
    CartItemId:string;
    ItemDescription:string;
    ProductId:string;
}

@Injectable()
export class UserContext{
    UserId:string;
    UserName:string;
    UserLastName:string;
    Address:string;
    Phone:string;
    Mail:string;
    Roles:Array<RoleModel>=[];
    Token:string;
    currentCart:Cart;
    PendingReviews:Array<PendingReview>=[];
    pendingReviewQuantity:number=0;
    Points:number=0;
    
    public checkRole(roleToCheck:string){
        for (let role of this.Roles){
            if(role.RoleId==roleToCheck){
                return true;
            }
        }
        return false;
    }

    public cleanContext() {
        this.UserId=null;
        this.UserName=null;
        this.UserLastName=null;
        this.Address=null;
        this.Phone=null;
        this.Mail=null;
        this.Roles=[];
        this.currentCart=null;
        this.PendingReviews=[];
        this.Points=0;
    }
    private fillRolesDTO(rolesDTO:any){
        this.Roles=[];
        for (let role of rolesDTO){
            this.Roles.push(role);
        }
    }
    private fillUserDTO(userDTO:any){
        this.UserId=userDTO.UserId;
        this.UserName=userDTO.UserName;
        this.UserLastName=userDTO.UserLastName;
        this.Address=userDTO.Address;
        this.Phone=userDTO.Phone;
        this.Mail=userDTO.EMail;
        this.Points=userDTO.Points;
        this.fillRolesDTO(userDTO.Roles);
    }

    private fillCartDTO(cartDTO:any){
        let cart:Cart=new Cart();
        if(cartDTO!=null){
            cart.cartId=cartDTO.cartId;
            cart.total=cartDTO.Total;
            cart.itemsDTO=cartDTO.itemsDTO;
            this.currentCart=cart;
        }else{
            this.currentCart=null;
        }
        
    }

    private FillPendingsReviewDTO(pendingReviews:any){
        let pendingRevQuantity:number=0;
        this.PendingReviews=[];
        for (let pendingReview of pendingReviews){
           this.PendingReviews.push(pendingReview);
           pendingRevQuantity=pendingRevQuantity  + 1;
        }
        this.pendingReviewQuantity=pendingRevQuantity;
    }
   
   fillContext(loginResponse:any)  {
        if(loginResponse.Success){
            this.fillUserDTO(loginResponse.Data.UserDTO);
            this.fillCartDTO(loginResponse.Data.PendingCart);
            this.FillPendingsReviewDTO(loginResponse.Data.PendingsReviewDTO);
            this.Token=loginResponse.Data.Token;
        }
    }

    userIsLoged():boolean{
        return this.UserId!=null;
    }

    userIsClient():boolean{
        return this.userIsLoged()  && this.checkRole("client");
    }

    userIsAdmin():boolean{
        return this.userIsLoged() && this.checkRole("admin");
    }

    havePendingCart():boolean{
        return this.currentCart!=null;
    }

    havePendingReview():boolean{
        return this.pendingReviewQuantity>0;
    }
}