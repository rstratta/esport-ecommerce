import { Component, Input, Output,EventEmitter, OnChanges} from '@angular/core';
import { UserService } from '../user/user.service';
import { RoleService } from '../role/role.service';
import { ResponseHandler } from '../response/responseHandler';
import { UserModel } from '../user/user.model';
import { RoleModel } from '../role/role.model';

@Component({
    selector: 'addOrRemoveRoleFromUser',
    templateUrl: './addOrRemoveRoleInUser.html'
})

export class AddOrRemoveRoleInUserComponent{
    @Input() private addRoleInUserAction: boolean = false;
    
    @Output() removeRoleFromUser: EventEmitter<UserModel> = new EventEmitter<UserModel>();
    @Output() addRoleInUser: EventEmitter<UserModel> = new EventEmitter<UserModel>();
    rolesToShow:Array<RoleModel>;

    constructor(private roleService:RoleService,
     private userService:UserService, private responseHanlder:ResponseHandler, private userModel:UserModel){
        
    }
    
    ngOnInit():void{
        if(this.addRoleInUserAction){
            this.activeAddRoleView();
        }else{
            this.activeRemoveRoleView();
        }
    }
    ngOnChanges(){

    }

  

    activeAddRoleView(): void {
        this.loadListModel();
    }

    loadListModel(){
        let rolesInUser: Array<RoleModel> = [];
        let allRoles: Array<RoleModel> = [];
        this.roleService.getAllActiveRoles().subscribe(
            response => {
                for(let role of response){
                    allRoles.push(role);
                }
                this.mergeProductList(allRoles, this.userModel.Roles);
            },
            error => { this.responseHanlder.buildBadResponse("Error al obtener roles"); }
        );



    }
    private mergeProductList(mandatoryList: Array<RoleModel>, auxiliarList: Array<RoleModel>) {
        this.rolesToShow = [];
        for (let role of mandatoryList) {
            if (auxiliarList.find(roleIter => roleIter.RoleId == role.RoleId) == null) {
                this.rolesToShow.push(role);
            }
        }
    }
    activeRemoveRoleView(): void {
        this.rolesToShow=[];
        this.rolesToShow=this.userModel.Roles;
    }

   onClickAddRoleInUser(role:RoleModel): void {
        let userModelRequest:UserModel=new UserModel();
        userModelRequest.UserId=this.userModel.UserId;
        userModelRequest.RoleId=role.RoleId;
        this.addRoleInUser.emit(userModelRequest);
        this.activeAddRoleView();
    }

    onClickRemoveRoleFromUser(role:RoleModel): void {
        let userModelRequest:UserModel=new UserModel();
        userModelRequest.UserId=this.userModel.UserId;
        userModelRequest.RoleId=role.RoleId;
        this.removeRoleFromUser.emit(userModelRequest);
        this.activeRemoveRoleView();
    }

}



    