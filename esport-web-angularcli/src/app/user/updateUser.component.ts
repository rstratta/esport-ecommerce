import { Component } from '@angular/core';
import { UserService } from './user.service';
import { UserModel } from '../user/user.model';
import { Router } from '@angular/router';
import { ResponseHandler } from '../response/responseHandler';

@Component({
    selector: 'esport-app',
    templateUrl: './updateUser.html',
})


export class UpdateUserComponent {
    localTitle: string = "Editar usuario";
    isLoading: boolean = false;
    constructor(private userService: UserService, private userModel: UserModel,
     private responseHandler:ResponseHandler, private router:Router) {

    }


    updateUser(userModel: UserModel) {
        this.isLoading = true;
        this.userService.updateUser(userModel).subscribe(
            response => {
                this.responseHandler.processResponse(response);
                this.isLoading = false;
                if (response.Success) {
                    this.router.navigate(["/showUsers"]);
                }
            },error=>{
                this.isLoading = false;
                this.responseHandler.buildBadResponse("Error al actualizar usuario");});
    }

}