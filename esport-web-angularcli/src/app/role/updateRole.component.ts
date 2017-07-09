import { Component } from '@angular/core';
import { RoleService } from './role.service';
import { Router } from '@angular/router';
import { RoleModel } from './role.model';
import { ResponseHandler } from '../response/responseHandler'

@Component({
    selector: 'esport-app',
    templateUrl: './updateRole.html'
})

export class UpdateRoleComponent{
    isLoading:boolean=false;

    constructor(private roleService:RoleService, private router:Router, 
    private roleModel:RoleModel, private responseHandler:ResponseHandler){}
   
    updateRole(roleModel:RoleModel):void{
        this.roleService.updateRole(roleModel).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading=false;
                this.router.navigate(["/showRoles"]);
            },error=> {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al actualizar rol");});
    }
}