import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../models/customer.model';

@Injectable()
export class CustomerService{

    constructor(private getHttp:HttpClient,private putHttp:HttpClient){

    }
    public getAllCustomersFromApi(){
        return this.getHttp.get("http://localhost:61488/api/Customer");
    }

    public addCustomerUsingApi(customer:Customer){
        return this.getHttp.post("http://localhost:61488/api/Customer",customer);
    }

    public updateCustomer(id:number,customer:Customer){
        return this.putHttp.put("http://localhost:61488/api/Customer/"+id,customer);
    }
}