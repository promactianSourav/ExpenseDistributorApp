import { NgForm } from '@angular/forms';
import { FriendService, FriendAC, GroupAC, GroupService, GroupTypeAC, GroupListAC, GroupedUserAC, GroupedUserDetailsAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';
import { cwd } from 'process';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrls: ['./add-group.component.css']
})
export class AddGroupComponent implements OnInit {

  constructor(private friendService:FriendService,private groupService:GroupService) { }

  friendList:FriendAC[] = [];
  groupTypeList:GroupTypeAC[] = [];
  groupedUserListIncluded:GroupedUserDetailsAC[] = [];
  userId:number = Number(localStorage.getItem('Id'));
  friendId:number = Number(localStorage.getItem('friendId'));
  group:GroupAC = new GroupAC();
  groupRegistered:GroupListAC = new GroupListAC();
  groupName:string = null;
  groupTypeId:number = null;

  checkCreate:boolean = true;

  ngOnInit(): void {

    
    this.userId = Number(localStorage.getItem('Id'));
    this.friendId = Number(localStorage.getItem('friendId'));

    this.friendService.getList(this.userId).subscribe(response =>  {
      this.friendList = response;
    });

    this.groupService.getGroupTypeList(this.userId).subscribe(response =>{
      this.groupTypeList = response;
    });
  }

  get create(){
    return this.checkCreate;
  }
  CreateGroup(formData:NgForm){

    this.userId = Number(localStorage.getItem('Id'));
    this.group.groupName = this.groupName;
    this.group.groupTypeId = this.groupTypeId;
  
    
    this.groupService.create(this.userId,this.group).subscribe(response =>{
      this.groupRegistered = response;
      console.log(response);
      
      if(response!=null){
        this.checkCreate = false;
      }
    });
   
   
  }

  groupedUser:GroupedUserAC = new GroupedUserAC();

  IncludeInGroup(friendId:number){
    this.userId = Number(localStorage.getItem('Id'));
    this.groupedUser.groupId = this.groupRegistered.groupId;
    this.groupedUser.groupsFriendId = friendId;
    
    this.groupService.addFriendInGroup(this.userId,this.groupedUser).subscribe(response =>{
      this.groupedUserListIncluded = response;
      console.log(this.groupedUserListIncluded);
      
    });
  }

  groupedUserDelete:GroupedUserAC = new GroupedUserAC();
  ExcludeFromGroup(groupId:number,groupsFriendId:number){
    this.userId = Number(localStorage.getItem('Id'));
    this.groupedUserDelete.groupId = groupId;
    this.groupedUserDelete.groupsFriendId = groupsFriendId;
    this.groupService.deleteFriendInGroup(this.userId,this.groupedUserDelete).subscribe(response =>{
      this.groupedUserListIncluded = response;
      console.log(this.groupedUserListIncluded);
    });
  }

}
