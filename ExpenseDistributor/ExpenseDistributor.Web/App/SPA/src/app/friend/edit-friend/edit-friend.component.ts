import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FriendService, FriendCreateAC } from 'src/app/Services/ApiClientGenerated.service';

@Component({
  selector: 'app-edit-friend',
  templateUrl: './edit-friend.component.html',
  styleUrls: ['./edit-friend.component.css']
})
export class EditFriendComponent implements OnInit {

  constructor(private friendService:FriendService,private route:ActivatedRoute,private router:Router) { }

  friend:FriendCreateAC = new FriendCreateAC();
  name:string = null;
  email:string = null;
  phoneNumber:string = null;
  
  userId:number = Number(localStorage.getItem('Id'));
  
  
  friendId:number = Number(this.route.snapshot.paramMap.get('friendId'));
  ngOnInit(): void {
    this.friendService.getFriend(this.userId,this.friendId).subscribe(response =>{
      this.email = response.email;
      this.name = response.name;
      this.phoneNumber = response.phoneNumber;
    })
  }

  EditFriend(formData:NgForm){

    this.friend.name = this.name;
    this.friend.email = this.email;
    this.friend.phoneNumber = this.phoneNumber;
    this.friendService.update(this.userId,this.friendId,this.friend).subscribe(response =>{
      // console.log(response);
      
    });
    let url:string = 'user/friends/';
    this.router.navigate([url]);
  }
}
