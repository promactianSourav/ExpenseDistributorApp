import { DetailsGroupComponent } from './details-group/details-group.component';
import { EditGroupComponent } from './edit-group/edit-group.component';
import { AddGroupComponent } from './add-group/add-group.component';
import { ListGroupComponent } from './list-group/list-group.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path:'user/groups',component:ListGroupComponent},
  {path:'user/groups/add',component:AddGroupComponent},
  {path:'user/groups/:groupId/edit',component:EditGroupComponent},
  {path:'user/groups/:groupId',component:DetailsGroupComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GroupRoutingModule { }
