import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NonGroupTransactionComponent } from './non-group-transaction/non-group-transaction.component';


@NgModule({
  declarations: [LoginComponent, RegisterComponent, DashboardComponent, NonGroupTransactionComponent],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    BrowserModule,
    UserRoutingModule
  ]
})
export class UserModule { }
