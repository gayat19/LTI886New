import { HttpClient } from "@angular/common/http";
import {  Injectable } from "@angular/core";
import { User } from "../models/user.model";

@Injectable()
export class UserService{

    constructor(private httpClient:HttpClient){
    }

    public LoginCheckUsingApi(user:User){
        return this.httpClient.post("http://localhost:58902/api/User",user);
    }

}