import { GroupService, GroupAC, ExpenseService, ExpenseAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-group',
  templateUrl: './list-group.component.html',
  styleUrls: ['./list-group.component.css']
})
export class ListGroupComponent implements OnInit {

  groupList:GroupAC[] = [];
  expenseList:ExpenseAC[] = [];
  userId:number = Number(localStorage.getItem('Id'));
  constructor( private groupService:GroupService,private expenseService:ExpenseService) {
    this.groupService.getList(this.userId).subscribe( response =>{
        this.groupList = response;
        console.log(response);
    });


    // this.expenseService.getList()

   }

  ngOnInit(): void {
  }

}
