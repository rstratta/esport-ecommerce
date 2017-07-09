import { Component } from '@angular/core';
import { UserService } from './user.service';
import { UserModel } from '../user/user.model';
import { Router } from '@angular/router';
import { ResponseHandler } from '../response/responseHandler';

@Component({
  selector: 'esport-app',
  templateUrl: './addUser.html',
})


export class AddUserComponent {
  localTitle: string = "Registrar Usuario";
  isLoading: boolean = false;
  constructor(private userService: UserService, private responseHandler: ResponseHandler, private router: Router) {

  }


  addUser(userModel: UserModel) {
    this.userService.addUser(userModel).subscribe(
      response => {
        this.responseHandler.processResponse(response);
        this.isLoading = false;
        if (response.Success) {
          this.router.navigate(["/mainPanel"]);
        }
      }, error => {
        this.isLoading = false;
        this.responseHandler.buildBadResponse("Error al agregar  usuario");});
  }

}