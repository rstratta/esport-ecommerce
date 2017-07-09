import { Component } from '@angular/core';
import { UserService } from './user.service';
import { UserModel } from '../user/user.model';
import { Router } from '@angular/router';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './addRoleInUser.html'
})

export class AsignRoleToUserComponent {
    isLoading:boolean=false;

    constructor(private router: Router, private userService: UserService,
        private userModel: UserModel, private responseHandler: ResponseHandler) {
    }

    addRoleInUser(userRoleRequest: any): void {
        this.isLoading=true;
        this.userService.addRoleOnUser(userRoleRequest).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading=false;
                if (response.Success) {
                    this.router.navigate(["/showUsers"]);
                }
            }, error=> {this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al agregar rol al usuario");});
    }


}