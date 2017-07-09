import { Component, Input, Output,EventEmitter} from '@angular/core';
import {UserModel} from '../user/user.model';
import { RoleService } from '../role/role.service';
import { RoleModel } from '../role/role.model';

@Component({
    selector: 'user-form',
    templateUrl: './userForm.html',
})

export class UserFormComponent{
    @Input() updateAction:boolean=false;
    @Input() isAnAdminAction:boolean=false;
    @Input() userModel:UserModel;
    @Input() title:string;
    @Input() roles:Array<RoleModel>;
    @Output() signUpUser: EventEmitter<UserModel> = new EventEmitter<UserModel>();
    @Output() updateUser: EventEmitter<UserModel> = new EventEmitter<UserModel>();
    
   
    constructor(private roleService:RoleService){
        this.userModel=new UserModel();
    }

    ngOnInit(){
        if(this.isAnAdminAction){
            this.roleService.getAllRoles().subscribe(response=> this.processRoleResponse(response));
        }
    }


    processRoleResponse(rolesResponse:Array<RoleModel>){
        this.roles=new Array<RoleModel>();
        for(let role of rolesResponse){
            if(!role.Eliminated){
                  this.roles.push(role);
            }
        }
    }
    onClickSignUp(): void {
        this.signUpUser.emit(this.userModel);
    }

    onClickUpdateUser():void{
        this.updateUser.emit(this.userModel);
    }

    
}