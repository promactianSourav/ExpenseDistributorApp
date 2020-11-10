import { ExpenseService, ExpenseAC, SplitType, Currency } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FriendService, GroupService, FriendAC, GroupTypeAC, GroupedUserDetailsAC, GroupAC, GroupListAC, GroupedUserAC } from 'src/app/Services/ApiClientGenerated.service';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.css']
})
export class AddExpenseComponent implements OnInit {

  constructor(private datePipe:DatePipe,private friendService:FriendService,private groupService:GroupService,private expenseService:ExpenseService,private route:ActivatedRoute) { }

  deleteFriend:FriendAC = new FriendAC();
  friendList:FriendAC[] = [];
  friendSelectedList:FriendAC[] = [];
  splitTypeList:SplitType[] = [];
  currenyList:Currency[] = [];
  groupTypeList:GroupTypeAC[] = [];
  groupedUserListIncluded:GroupedUserDetailsAC[] = [];
  userId:number = Number(localStorage.getItem('Id'));
  friendId:number = Number(localStorage.getItem('friendId'));
  groupId:number = Number(this.route.snapshot.paramMap.get('groupId'));
  group:GroupAC = new GroupAC();

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

  cent2:number = null;


  groupRegistered:GroupListAC = new GroupListAC();
  groupName:string = null;
  groupTypeId:number = null;

  checkCreate:boolean = true;

  ngOnInit(): void {

    this.date = this.datePipe.transform(this.date2,'dd/MM/yyyy');
    this.userId = Number(localStorage.getItem('Id'));
    this.friendId = Number(localStorage.getItem('friendId'));

    this.friendService.getList(this.userId).subscribe(response =>  {
      this.friendList = response;
    });

    this.groupService.getGroupTypeList(this.userId).subscribe(response =>{
      this.groupTypeList = response;
    });

    this.expenseService.getListSplitTypes(this.groupId).subscribe(response =>{
      this.splitTypeList = response;
    });

    this.expenseService.getListCurrencies(this.groupId).subscribe(response =>{
      this.currenyList = response;
    });
  }

  get create(){
    return this.checkCreate;
  }

  onChangeInput(val:number){
    // console.log(val);
    
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

    this.friendService.getFriend(this.userId,friendId).subscribe(response => {
      this.friendSelectedList.push(response);
      this.friendSelectedList = this.friendSelectedList.filter((test,index,array) => 
      index === array.findIndex((findTest) => findTest.name === test.name));
    });

    this.ngOnInit();
   
  }

  groupedUserDelete:GroupedUserAC = new GroupedUserAC();
  ExcludeFromGroup(friendId:number){
    this.userId = Number(localStorage.getItem('Id'));
    
    this.friendSelectedList.forEach(element => {
      if(element.friendId == friendId){
        this.deleteFriend = element;
      }
     
    });

    this.friendSelectedList = this.friendSelectedList.filter( item => item != this.deleteFriend);
    this.ngOnInit();
    
  }
  SendToTransact(clickfriendId:number,amt:number){
    this.expense.expenseName = this.expenseName;
    this.expense.payerFriendId = this.payerFriendId;
    this.expense.debtFriendId = clickfriendId;
    this.expense.creatorFriendId = this.friendId;
    this.expense.groupId = this.groupId;
    this.expense.splitTypeId = this.splitTypeId;
    this.expense.currencyId = this.currencyId;
    this.expense.date = this.date;
    this.expense.amount = amt;

    console.log(this.expense);
    
  }

}
