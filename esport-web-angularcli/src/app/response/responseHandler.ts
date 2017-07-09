import { Injectable } from '@angular/core';
import {ResponseModel} from './responseModel';
@Injectable()
export class ResponseHandler{
    

    constructor(private responseModel:ResponseModel){}
    
    processResponse(response:any):void{
        this.responseModel.isSuccess=response.Success;
        this.responseModel.message=response.Message;
        this.responseModel.showMessage=true;
    }

    buildBadResponse(message:string):void{
        this.responseModel.isSuccess=false;
        this.responseModel.message=message;
        this.responseModel.showMessage=true;
    }

    hideMessage():void{
        this.responseModel.showMessage=false;
    }
}