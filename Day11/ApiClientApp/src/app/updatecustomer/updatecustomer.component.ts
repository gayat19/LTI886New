import { Component, OnInit } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-updatecustomer',
  templateUrl: './updatecustomer.component.html',
  styleUrls: ['./updatecustomer.component.css']
})
export class UpdatecustomerComponent implements OnInit {

  customers:any;
  customer:Customer;
  constructor(private customerService:CustomerService) { 
      this.customer = new Customer();
      this.customerService.getAllCustomersFromApi().subscribe(data=>{
        this.customers = data;
      });
  }

  findCustomer(cid:any){
    var id = cid.value;
    console.log(cid);
    this.customers.forEach((element: Customer) => {
      if(element.id == id)
          this.customer = element;
    });
  }

  updateCustomerData(){
    this.customerService.updateCustomer(this.customer.id,this.customer).subscribe(msg=>
      console.log("Called")
      );
  }

  ngOnInit(): void {
  }

}
