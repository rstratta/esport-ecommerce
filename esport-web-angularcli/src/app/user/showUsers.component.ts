import { Component } from '@angular/core';
import { UserService } from './user.service';
import { UserContext } from '../user/userContext';
import { Router } from '@angular/router';
import { UserModel } from './user.model';
import { ResponseHandler } from '../response/responseHandler';
@Component({
  selector: 'esport-app',
  templateUrl: './showUsers.html'
})


export class ShowUserComponent {
  users: Array<UserModel> = [];
  isLoading: boolean = false;


  constructor(private userService: UserService, private router: Router,
    private userModel: UserModel, private responseHandler: ResponseHandler) {

  }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getAllUsers().subscribe(response => {
      this.users=response;
      this.isLoading = false;
    }, error => {
      this.isLoading = false;
      this.responseHandler.buildBadResponse("Error al obtener usuarios");});
  }

  removeUser(user: any) {
    this.userService.removeUser(user).subscribe(response => {
      this.responseHandler.processResponse(response);
      this.loadUsers();
    }, error => {
      this.isLoading = false;
      this.responseHandler.buildBadResponse("Error al eliminar usuario");});
  }

  restoreUser(user: any) {
    user.Eliminated = false;
    this.userService.updateUser(user).subscribe(response => {
      this.responseHandler.processResponse(response);
      this.loadUsers();
    }, error => this.responseHandler.buildBadResponse("Error al restaurar usuario"));
  }

  updateUserModel(user: UserModel, url: string) {
    this.fillUserModel(user);
    this.router.navigate([url]);
  }

  fillUserModel(user: UserModel) {
    this.userModel.Roles = [];
    this.userModel.UserId = user.UserId;
    this.userModel.UserName = user.UserName;
    this.userModel.UserLastName = user.UserLastName;
    this.userModel.Address = user.Address;
    this.userModel.Phone = user.Phone;
    this.userModel.EMail = user.EMail;
    for (let role of user.Roles) {
      this.userModel.Roles.push(role);
    }
  }
}