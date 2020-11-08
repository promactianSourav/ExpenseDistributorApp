import { UserService, ExpenseService, UserAC, SettlementService } from './Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ExpenseDistributorSPA';
  userList:any[] = [];
  name:string = "";
  userId:number = Number(localStorage.getItem('Id'));
  constructor( private userService:UserService, private expenseService:ExpenseService, private settlementService:SettlementService,private router:Router){
    
  }
  ngOnInit(): void {
    
    this.name = localStorage.getItem('name');
    // this.userService.getlist().subscribe(response =>{
    //   console.log(response);
    //   }
    // );
    // this.settlementService.getListForUser(7).subscribe(response => console.log(response)
    // );
  }


  get signin() {
    this.name = localStorage.getItem('name');
    this.userId = Number(localStorage.getItem('Id'));
    return localStorage.getItem('Id') != null ? true : false;
  }
  logout() {
    localStorage.removeItem('Id');
    localStorage.removeItem('friendId');
    localStorage.clear();
    this.router.navigate(['user/login']);
  }
 
}
