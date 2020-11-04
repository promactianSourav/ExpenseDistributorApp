import { UserService, ExpenseService } from './Services/ApiClientGenerated.service';
import { ExpenseModule } from './expense/expense.module';
import { ExpenseRoutingModule } from './expense/expense-routing.module';
import { FriendModule } from './friend/friend.module';
import { FriendRoutingModule } from './friend/friend-routing.module';
import { GroupModule } from './group/group.module';
import { GroupRoutingModule } from './group/group-routing.module';
import { SettlementModule } from './settlement/settlement.module';
import { SettlementRoutingModule } from './settlement/settlement-routing.module';
import { UserRoutingModule } from './user/user-routing.module';
import { UserModule } from './user/user.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './sharedcomponent/home/home.component';
import { PagenotfoundComponent } from './sharedcomponent/pagenotfound/pagenotfound.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PagenotfoundComponent
  ],
  imports: [ 
    FormsModule,
    CommonModule,
    HttpClientModule,
    BrowserModule,
    UserRoutingModule,
    UserModule,
    SettlementRoutingModule,
    SettlementModule,
    GroupRoutingModule,
    GroupModule,
    FriendRoutingModule,
    FriendModule,
    ExpenseRoutingModule,
    ExpenseModule,
    AppRoutingModule
  ],
  providers: [UserService,ExpenseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
