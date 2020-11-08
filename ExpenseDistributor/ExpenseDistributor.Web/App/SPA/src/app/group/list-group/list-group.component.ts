import { SharedDataService } from './../../Services/shared-data.service';
import { GroupService, GroupAC, ExpenseService, ExpenseAC, LentBorrowAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-group',
  templateUrl: './list-group.component.html',
  styleUrls: ['./list-group.component.css']
})
export class ListGroupComponent implements OnInit {

  gr:LentBorrowAC;
  groupList:GroupAC[] = [];
  expenseList:ExpenseAC[] = [];
  groupRecordList:LentBorrowAC[] = [];
  userId:number = Number(localStorage.getItem('Id'));
  friendId:number = Number(localStorage.getItem('friendId'));
  constructor( private groupService:GroupService,private expenseService:ExpenseService,private sharedData:SharedDataService) {
    
  }

  ngOnInit(): void {
  
    // this.userId = this.sharedData.getuserIdData();
    // this.friendId = this.sharedData.getfriendIdData();
    
  this.userId = Number(localStorage.getItem('Id'));
  this.friendId = Number(localStorage.getItem('friendId'));
    
    
    this.groupService.getList(this.userId).subscribe( response =>{
      this.groupList = response;
    });

    this.groupService.getExpensesRecordForGroups(this.friendId,this.userId).subscribe(response =>{
      this.groupRecordList = response;
    });
  }

}
