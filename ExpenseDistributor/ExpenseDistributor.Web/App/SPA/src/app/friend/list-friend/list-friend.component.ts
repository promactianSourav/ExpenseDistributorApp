import { FriendService, FriendBoardDetailsAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-friend',
  templateUrl: './list-friend.component.html',
  styleUrls: ['./list-friend.component.css']
})
export class ListFriendComponent implements OnInit {

  constructor(private friendService:FriendService) { }
  userId:number = Number(localStorage.getItem('Id'));
  friendDetailsList:FriendBoardDetailsAC[] = [];
  ngOnInit(): void {
    this.userId = Number(localStorage.getItem('Id'));
    this.friendService.getFriendBoardDetails(this.userId).subscribe(response =>{
        this.friendDetailsList = response;
    });
  }

}
