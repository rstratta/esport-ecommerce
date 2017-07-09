import { Component } from '@angular/core';
import { RoleService } from './role.service';
import { Router } from '@angular/router';
import { RoleModel } from './role.model';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './addRole.html',
})

export class AddRoleComponent {
    isLoading: boolean = false;
    private roles: Array<any> = [];

    constructor(private roleService: RoleService, private router: Router, private responseHandler: ResponseHandler) {
    }
    addRole(roleModel: RoleModel): void {
        this.roleService.addRole(roleModel).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
                if (response.Success) {
                    this.router.navigate(["/mainPanel"]);
                }
            }, error => {
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al agregar rol");});
    }
}
