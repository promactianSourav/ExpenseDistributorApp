import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettlementRoutingModule } from './settlement-routing.module';
import { ListTransactionComponent } from './list-transaction/list-transaction.component';


@NgModule({
  declarations: [ListTransactionComponent],
  imports: [
    CommonModule,
    SettlementRoutingModule
  ]
})
export class SettlementModule { }
