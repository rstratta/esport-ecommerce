import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http, HttpModule, JsonpModule } from '@angular/http';
import { UserContext } from './user/userContext';
import { LoginService } from './login/login.service';
import { ResponseModel } from './response/responseModel';


@Component({
  selector: 'esport-app',
  templateUrl: './home/home.html'
})


export class AppComponent {


  constructor(private router: Router, private http: Http, activatedRoute: ActivatedRoute,
    private loginService: LoginService, private userContext: UserContext, private responseModel:ResponseModel) {

  }



  ngOnInit() {
     this.router.navigate(['mainPanel']);
  }

  logoutUser() {
    this.loginService.logout(this.userContext.Token);
  }


 

}
