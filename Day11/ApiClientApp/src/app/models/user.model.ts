export class User{
    userid:string;
    password:string;
    username:string ="";
    constructor(username:string="",password:string=""){
        this.userid = username;
        this.password = password;
    }
}