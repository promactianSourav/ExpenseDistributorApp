import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FriendService, GroupService, FriendAC, GroupTypeAC, GroupedUserDetailsAC, GroupAC, GroupListAC, GroupedUserAC } from 'src/app/Services/ApiClientGenerated.service';

@Component({
  selector: 'app-edit-group',
  templateUrl: './edit-group.component.html',
  styleUrls: ['./edit-group.component.css']
})
export class EditGroupComponent implements OnInit {

  constructor(private friendService:FriendService,private groupService:GroupService,private route:ActivatedRoute,private router:Router) { }

  friendList:FriendAC[] = [];
  groupTypeList:GroupTypeAC[] = [];
  groupedUserListIncluded:GroupedUserDetailsAC[] = [];
  userId:number = Number(localStorage.getItem('Id'));
  friendId:number = Number(localStorage.getItem('friendId'));
  groupId:number = Number(this.route.snapshot.paramMap.get('groupId'));
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

    this.groupService.getGroup(this.userId,this.groupId).subscribe(response =>{
        this.groupName = response.groupName;
        this.groupTypeId = response.groupTypeId;
    });

    this.groupService.getEditGroupFriendDetails(this.userId,this.groupId).subscribe(response => {
      this.groupedUserListIncluded = response;
    });
  }

  get create(){
    return this.checkCreate;
  }
  EditGroup(formData:NgForm){

    this.userId = Number(localStorage.getItem('Id'));
    this.group.groupName = this.groupName;
    this.group.groupTypeId = this.groupTypeId;
  
    
    // this.groupService.create(this.userId,this.group).subscribe(response =>{
    //   this.groupRegistered = response;
    //   console.log(response);
      
    //   if(response!=null){
    //     this.checkCreate = false;
    //   }
    // });

    this.groupService.update(this.userId,this.groupId,this.group).subscribe(response =>{
      this.groupRegistered = response;
    });
   
    this.ngOnInit();
    this.router.navigate(['user/groups/']);
   
  }

  groupedUser:GroupedUserAC = new GroupedUserAC();

  IncludeInGroup(friendId:number){
    this.userId = Number(localStorage.getItem('Id'));
    this.groupedUser.groupId = this.groupId;
    this.groupedUser.groupsFriendId = friendId;
    
    this.groupService.addFriendInGroup(this.userId,this.groupedUser).subscribe(response =>{
      // this.groupedUserListIncluded = response;
      // console.log(this.groupedUserListIncluded);
      
    });

    this.ngOnInit();
    this.groupService.getEditGroupFriendDetails(this.userId,this.groupId).subscribe(response => {
      this.groupedUserListIncluded = response;
    });
  }

  groupedUserDelete:GroupedUserAC = new GroupedUserAC();
  ExcludeFromGroup(groupId:number,groupsFriendId:number){
    this.userId = Number(localStorage.getItem('Id'));
    this.groupedUserDelete.groupId = groupId;
    this.groupedUserDelete.groupsFriendId = groupsFriendId;
    // console.log(this.groupedUserDelete);
    // console.log(this.userId);
    
    this.groupService.deleteFriendInGroup(this.userId,this.groupedUserDelete).subscribe(response =>{
      // this.groupedUserListIncluded = response;
      // console.log(this.groupedUserListIncluded);
      // console.log(response);
      
    });

    this.ngOnInit();
    this.groupService.getEditGroupFriendDetails(this.userId,this.groupId).subscribe(response => {
      this.groupedUserListIncluded = response;
    });
  }


}
