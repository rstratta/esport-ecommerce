import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { UserContext } from '../user/userContext';
import { Router } from '@angular/router';
import { UrlBackendProvider } from '../urlBackendProvider';
import { ResponseHandler } from '../response/responseHandler';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';

@Injectable()
export class UserService {


    constructor(private router: Router, private http: Http,
        private userContext: UserContext,
        private urlBackendProvider: UrlBackendProvider,
        private responseHandler: ResponseHandler) { }



    private processResponse(response: any) {
        this.responseHandler.processResponse(response);
        if(response.Data!=null){
            this.userContext.fillContext(response);
        }
    }

    addUser(userRequest: any): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.post(this.urlBackendProvider.getBaseDir() + "/addUser", userRequest, { headers: header }).map(response => response.json())).map(usersResponse => {
                return usersResponse;
            });
    }

    removeUser(userRequest: any): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.delete(this.urlBackendProvider.getBaseDir() + "/removeUser", { headers: header, body: userRequest })
         .map(response => response.json())).map(usersResponse => {
                return usersResponse;
            });
    }

    updateUser(userRequest: any): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.put(this.urlBackendProvider.getBaseDir() + "/editUser", userRequest, { headers: header })
        .map(response => response.json())).map(usersResponse => {
                return usersResponse;
            });
    }

    updatePassword(userRequest: any) {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        this.http.put(this.urlBackendProvider.getBaseDir() + "/updatePassword", userRequest, { headers: header }).subscribe(
            response => {
                let userResponse = response.json();
                this.processResponse(userResponse);
            }, error => {
                this.responseHandler.buildBadResponse("Ocurrió un error actualizar password de usuario. Reintente");
            }
        );
    }

    

    getAllUsers(): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.get(this.urlBackendProvider.getBaseDir() + "/allUsers",
            { headers: header }).map(response => response.json())).map(usersResponse => {
                return usersResponse.Data;
            });
    }

    addRoleOnUser(userRequest: any): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
       return (this.http.post(this.urlBackendProvider.getBaseDir() + "/addRoleOnUser", userRequest, { headers: header })
       .map(response => response.json())).map(userResponse=>{return userResponse});
    }

    removeRoleFromUser(userRequest: any): Observable<any> {
        let header = new Headers();
        header.append('Token', this.userContext.Token);
        return (this.http.delete(this.urlBackendProvider.getBaseDir() + "/removeRoleFromUser", { headers: header , body:userRequest})
        .map(response => response.json())).map(userResponse=>{return userResponse});
    }
}