import { Component, Input, Output,EventEmitter, OnChanges} from '@angular/core';
import { RoleModel } from '../role/role.model';
@Component({
    selector: 'role-form',
    templateUrl: './roleForm.html'
})

export class SharedRoleComponent implements OnChanges{
    @Input() roleModel:RoleModel;
    @Input() updateAction:boolean=false;
    @Output() addRole: EventEmitter<RoleModel> = new EventEmitter<RoleModel>();
    @Output() updateRole: EventEmitter<RoleModel> = new EventEmitter<RoleModel>();

    constructor(){
        this.roleModel=new RoleModel();
    }
    
    ngOnChanges(){

    }
   onClickAddRole(): void {
        this.addRole.emit(this.roleModel);
    }

    onClickUpdateRole(): void {
        this.updateRole.emit(this.roleModel);
    }

}