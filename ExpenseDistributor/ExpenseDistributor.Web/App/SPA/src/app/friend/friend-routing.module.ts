import { EditFriendComponent } from './edit-friend/edit-friend.component';
import { AddFriendComponent } from './add-friend/add-friend.component';
import { ListFriendComponent } from './list-friend/list-friend.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DetailsFriendComponent } from './details-friend/details-friend.component';

const routes: Routes = [
  {path:'user/friends',component:ListFriendComponent},
  {path:'user/friends/add',component:AddFriendComponent},
  {path:'user/friends/:friendId/edit',component:EditFriendComponent},
  {path:'user/friends/:friendId',component:DetailsFriendComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FriendRoutingModule { }
