import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-addcustomer',
  templateUrl: './addcustomer.component.html',
  styleUrls: ['./addcustomer.component.css']
})
export class AddcustomerComponent implements OnInit {

  customer:Customer;
  constructor(private customerService:CustomerService) { 
    this.customer = new Customer();
  }
  InsertCustomer(){
    this.customerService.addCustomerUsingApi(this.customer).subscribe(data=>console.log(data));
  }
  ngOnInit(): void {
  }

}
