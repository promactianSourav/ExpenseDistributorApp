import { GroupService } from 'src/app/Services/ApiClientGenerated.service';
import { ExpenseService, SettlementService, ExpenseCheckAC, SettlementPerExpenseExpandAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-details-group',
  templateUrl: './details-group.component.html',
  styleUrls: ['./details-group.component.css']
})
export class DetailsGroupComponent implements OnInit {

  constructor(private expenseService:ExpenseService,private settlementService:SettlementService,private groupService:GroupService,private route:ActivatedRoute,private router:Router) { }
  
  
  expenseList:ExpenseCheckAC[] = [];
  settlementList:SettlementPerExpenseExpandAC[] = [];
  
  userId:number = Number(localStorage.getItem('Id'));
  friendId:number = Number(localStorage.getItem('friendId'));
  groupId:number = Number(this.route.snapshot.paramMap.get('groupId'));
  groupName:string = "";
  ngOnInit(): void {

    this.groupService.getGroup(this.userId,this.groupId).subscribe(response =>{
        this.groupName = response.groupName;
    });
    this.expenseService.getExpenseCheckList(this.groupId,this.friendId).subscribe(response => {
      this.expenseList = response;
    });

    this.settlementService.getSettlementsListForExpenseList(this.groupId).subscribe(response =>{
      this.settlementList = response;
    });
  }

  // GoToEditGroup(){
  //   this.router.navigate(['user/groups/:groupId/edit']);
  // }

}
