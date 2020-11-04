import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FriendRoutingModule } from './friend-routing.module';
import { ListFriendComponent } from './list-friend/list-friend.component';
import { AddFriendComponent } from './add-friend/add-friend.component';
import { EditFriendComponent } from './edit-friend/edit-friend.component';
import { DetailsFriendComponent } from './details-friend/details-friend.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [ListFriendComponent, AddFriendComponent, EditFriendComponent, DetailsFriendComponent],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule,
    BrowserModule,
    FriendRoutingModule
  ]
})
export class FriendModule { }
