import { UserService, ExpenseService, UserAC, SettlementService } from './Services/ApiClientGenerated.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ExpenseDistributorSPA';
  userList:any[] = [];
  name:string = null;
  userId:number = Number(localStorage.getItem('Id'));
  constructor( private userService:UserService, private expenseService:ExpenseService, private settlementService:SettlementService,private router:Router){
    this.userService.get(Number(localStorage.getItem('Id'))).subscribe(response =>{
      console.log(response);
      this.name = response.name;
      console.log(this.name);
      
      console.log(localStorage.getItem('Id'));
      
      }
    );
    this.userService.getlist().subscribe(response =>{
      console.log(response);
      }
    );
    this.settlementService.getListForUser(7).subscribe(response => console.log(response)
    );
  }


  get signin() {
    // this.username = localStorage.getItem('username');
    return localStorage.getItem('Id') != null ? true : false;
  }
  logout() {
    localStorage.removeItem('Id');
    localStorage.removeItem('friendId');
    localStorage.clear();
    this.router.navigate(['user/login']);
  }
 
}
