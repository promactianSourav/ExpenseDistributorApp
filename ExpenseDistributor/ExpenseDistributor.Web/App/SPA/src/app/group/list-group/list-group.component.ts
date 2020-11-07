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
  constructor( private groupService:GroupService,private expenseService:ExpenseService) {
    this.groupService.getList(this.userId).subscribe( response =>{
        this.groupList = response;
    });


    this.groupService.getExpensesRecordForGroups(this.friendId,this.userId).subscribe(response =>{
        this.groupRecordList = response;
    });

   }

  ngOnInit(): void {
  }

}
