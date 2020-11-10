import { ExpenseExpandAC, SettlementPerExpenseExpandAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';
import { FriendService, FriendBoardDetailsAC } from 'src/app/Services/ApiClientGenerated.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details-friend',
  templateUrl: './details-friend.component.html',
  styleUrls: ['./details-friend.component.css']
})
export class DetailsFriendComponent implements OnInit {

  constructor(private friendService:FriendService,private route:ActivatedRoute) { }
  userId:number = Number(localStorage.getItem('Id'));
  
  
  friendId:number = Number(this.route.snapshot.paramMap.get('friendId'));
  friendDetails:FriendBoardDetailsAC = new FriendBoardDetailsAC();
  friendName:string = null;
  listExpense:ExpenseExpandAC[] = [];
  listSettlement:SettlementPerExpenseExpandAC[] = [];
  friendDetailsList:FriendBoardDetailsAC[] = [];
  ngOnInit(): void {
    this.userId = Number(localStorage.getItem('Id'));
    this.friendService.getFriendBoardDetails(this.userId).subscribe(response =>{
        this.friendDetailsList = response;
        response.forEach(element => {
          if(element.friendId == this.friendId){
            this.listExpense = element.listExpenses;
            this.listSettlement = element.listSettlements;
            this.friendName = element.friendName;
          }
        });
    });
  }

}
