import { FriendAC, FriendService, FriendCreateAC } from './../../Services/ApiClientGenerated.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-friend',
  templateUrl: './add-friend.component.html',
  styleUrls: ['./add-friend.component.css']
})
export class AddFriendComponent implements OnInit {

  constructor(private friendService:FriendService,private router:Router) { }

  friend:FriendCreateAC = new FriendCreateAC();
  name:string = null;
  email:string = null;
  phoneNumber:string = null;
  
  userId:number = Number(localStorage.getItem('Id'));
  ngOnInit(): void {
  }

  AddFriend(formData:NgForm){

    this.friend.name = this.name;
    this.friend.email = this.email;
    this.friend.phoneNumber = this.phoneNumber;
    this.friendService.create(this.userId,this.friend).subscribe(response =>{
      // console.log(response);
      
    });
    let url:string = 'user/friends/';
    this.router.navigate([url]);
  }

}
