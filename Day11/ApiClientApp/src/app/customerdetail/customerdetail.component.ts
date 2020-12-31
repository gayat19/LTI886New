import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customerdetail',
  templateUrl: './customerdetail.component.html',
  styleUrls: ['./customerdetail.component.css']
})
export class CustomerdetailComponent implements OnInit {

  id:number;
  customer:any;
  constructor(private myRoute:ActivatedRoute,private customerService:CustomerService) { 
      this.id= this.myRoute.snapshot.params["id"];
      console.log(this.id);
      this.customerService
      .getOneCustomersFromApi(this.id)
      .subscribe(data=> this.customer=data);
  }

  ngOnInit(): void {

  }

}
