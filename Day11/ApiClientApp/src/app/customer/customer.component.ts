import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customers:any;
  constructor(private customerService:CustomerService,
    private router:Router) { 
    this.customerService.getAllCustomersFromApi().subscribe(custs=>{
      this.customers = custs;
    })
  }
  showDetails(id:number){
    this.router.navigate(["detail",id])
  }
  ngOnInit(): void {
  }

}
