import { Component } from '@angular/core';
import { RoleService } from './role.service';
import { Router } from '@angular/router';
import { RoleModel } from './role.model';
import { ResponseHandler } from '../response/responseHandler'

@Component({
    selector: 'esport-app',
    templateUrl: './showRoles.html'
})

export class ShowRolesComponent{
    private roles:Array<any>=[];
    isLoading:boolean=false;
    
    constructor(private roleService:RoleService,
     private router:Router, private roleModel:RoleModel,private responseHandler:ResponseHandler){
    }

    ngOnInit(){
        this.loadRoles();
    }

    ngOnChanges( roleModel:RoleModel){
        this.loadRoles();
    }

    loadRoles(){
        this.roleService.getAllRoles().subscribe(response=> this.roles=response, 
        error=>{
            this.isLoading = false;
            this.responseHandler.buildBadResponse("Error al obtener roles.");});
    }
    updateRoleModel(roleModel:RoleModel):void{
        this.roleModel.RoleId=roleModel.RoleId;
        this.roleModel.Description=roleModel.Description;
        this.roleModel.Eliminated=roleModel.Eliminated;
        this.router.navigate(['updateRole']);
    }

    restoreRole(roleModel:RoleModel):void{
        roleModel.Eliminated=false;
        this.roleService.updateRole(roleModel).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.loadRoles();
                this.isLoading=false;
            }, error=>{
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al restaurar rol");});
    }

    removeRole(roleModel:RoleModel):void{
        this.roleService.removeRole(roleModel).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.loadRoles();
                this.isLoading=false;
            }, error=> {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al eliminar rol");});
    }
}