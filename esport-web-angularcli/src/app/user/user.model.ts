import { RoleModel } from '../role/role.model';
export class UserModel{
     UserId:string;
     UserName:string;
     UserLastName:string;
     Password:string;
     Phone:string;
     Address:string;
     EMail:string;
     RoleId:string;
     RepeatPassword:string;
     NewPassword:string;
     Roles:Array<RoleModel>=[];
     
}