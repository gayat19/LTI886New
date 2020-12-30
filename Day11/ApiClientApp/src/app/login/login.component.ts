import { Component, OnInit } from '@angular/core';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLogin:User;
  user:any;
  msg:any;
  constructor(private userService:UserService) {
    this.userLogin = new User();
   }

   onLogin(){
     this.userService.LoginCheckUsingApi(this.userLogin).subscribe(
       u=>{this.user = u; this.msg=undefined},
       err=>this.msg = err.error.Message);
   }

  ngOnInit(): void {
  }

}
