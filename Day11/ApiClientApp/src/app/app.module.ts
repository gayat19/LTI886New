import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerService } from './services/customer.service';
import { AddcustomerComponent } from './addcustomer/addcustomer.component';
import { FormsModule } from '@angular/forms';
import { UpdatecustomerComponent } from './updatecustomer/updatecustomer.component';
import { UserService } from './services/user.service';
import { LoginComponent } from './login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { CustomerdetailComponent } from './customerdetail/customerdetail.component';

var myRoutes:Routes=[
  {path:"view",component:CustomerComponent},
  {path:"update",component:UpdatecustomerComponent},
  {path:"add",component:AddcustomerComponent},
  {path:"detail/:id",component:CustomerdetailComponent}
]
@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    AddcustomerComponent,
    UpdatecustomerComponent,
    LoginComponent,
    CustomerdetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(myRoutes)
  ],
  providers: [CustomerService,UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
