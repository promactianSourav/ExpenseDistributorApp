import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { FriendService, GroupService, ExpenseService, FriendAC, SplitType, Currency, ExpenseAC } from 'src/app/Services/ApiClientGenerated.service';

@Component({
  selector: 'app-edit-expense',
  templateUrl: './edit-expense.component.html',
  styleUrls: ['./edit-expense.component.css']
})
export class EditExpenseComponent implements OnInit {

  constructor(private datePipe:DatePipe,private friendService:FriendService,private groupService:GroupService,private expenseService:ExpenseService,private route:ActivatedRoute,private router:Router) { }

  friendList:FriendAC[] = [];
  splitTypeList:SplitType[] = [];
  currenyList:Currency[] = [];
  userId:number = Number(localStorage.getItem('Id'));
  friendId:number = Number(localStorage.getItem('friendId'));
  groupId:number = Number(this.route.snapshot.paramMap.get('groupId'));
  
  expenseId:number = Number(this.route.snapshot.paramMap.get('expenseId'));

  expense:ExpenseAC = new ExpenseAC();
  expenseName:string = null;
  payerFriendId:number = null;
  debtFriendId:number = null;
  creatorFriendId:number = null;
  splitTypeId:number = null;
  amount:number = null;
  Total:number = null;
  date:string = null;
  date2:Date = new Date();
  currencyId:number = null;


  ngOnInit(): void {


    this.date = this.datePipe.transform(this.date2,'dd/MM/yyyy');
    this.userId = Number(localStorage.getItem('Id'));
    this.friendId = Number(localStorage.getItem('friendId'));
    
    this.expenseId = Number(this.route.snapshot.paramMap.get('expenseId'));

    this.expenseService.getExpense(this.groupId,this.expenseId).subscribe(response => {
      this.expenseName = response.expenseName;
      this.payerFriendId = response.payerFriendId;
      this.debtFriendId = response.debtFriendId;
      this.creatorFriendId = response.creatorFriendId;
      this.amount = response.amount;
      this.currencyId = response.currencyId;
      this.splitTypeId = response.splitTypeId;
      this.groupId = response.groupId;
      this.date = response.date;

    })

    this.friendService.getList(this.userId).subscribe(response =>  {
      this.friendList = response;
    });


    this.expenseService.getListSplitTypes(this.groupId).subscribe(response =>{
      this.splitTypeList = response;
    });

    this.expenseService.getListCurrencies(this.groupId).subscribe(response =>{
      this.currenyList = response;
    });
  }


  EditExpense(formData:NgForm){

    this.expense.expenseName = this.expenseName;
    this.expense.payerFriendId = this.payerFriendId;
    this.expense.debtFriendId = this.debtFriendId;
    this.expense.creatorFriendId = this.creatorFriendId;
    this.expense.amount = this.amount;
    this.expense.currencyId = this.currencyId;
    this.expense.splitTypeId = this.splitTypeId;
    this.expense.date = this.date;
    this.expense.groupId = this.groupId;
    // console.log(this.expense);
    

    this.expenseService.update(this.groupId,this.expenseId,this.expense).subscribe(response =>{

    });

    let url:string = 'user/groups/'+this.groupId;
    this.router.navigate([url]);
  }
}
