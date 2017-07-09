import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import {UrlBackendConfig} from './urlBackendConfig';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';


@Injectable()
export class UrlBackendProvider{
   private urlBackendConfig:UrlBackendConfig=new UrlBackendConfig();

    constructor(private http:Http){
       
    }

   
    config():Observable<UrlBackendConfig>{
       return (this.http.get("./serverConfig.json").map(response => response.json())).
          map(data => {
             this.urlBackendConfig.serverIp=data.serverIp;
            this.urlBackendConfig.serverPort=data.serverPort;
            this.urlBackendConfig.protocol=data.protocol;
        return this.urlBackendConfig;
    });        
    }

    getBaseDir():string{
        return this.urlBackendConfig.protocol+"://"+this.urlBackendConfig.serverIp+":"+this.urlBackendConfig.serverPort+"/esport";
    }
}