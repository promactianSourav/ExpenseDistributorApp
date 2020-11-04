import { EditExpenseComponent } from './edit-expense/edit-expense.component';
import { AddExpenseComponent } from './add-expense/add-expense.component';
import { ListExpenseComponent } from './list-expense/list-expense.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path:'user/groups/:groupId/expenses',component:ListExpenseComponent},
  {path:'user/groups/:groupId/add',component:AddExpenseComponent},
  {path:'user/groups/:groupId/expenses/expenseId',component:EditExpenseComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExpenseRoutingModule { }
