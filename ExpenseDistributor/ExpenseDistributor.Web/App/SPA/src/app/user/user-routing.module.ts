import { DashboardComponent } from './dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NonGroupTransactionComponent } from './non-group-transaction/non-group-transaction.component';

const routes: Routes = [
  {path:'user/login',component:LoginComponent},
  {path:'user/register',component:RegisterComponent},
  {path:'user/dashboard',component:DashboardComponent},
  {path:'user/dashboard/:userId/nongrouptransaction',component:NonGroupTransactionComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
