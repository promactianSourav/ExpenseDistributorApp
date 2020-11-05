import { UserService, ExpenseService, UserAC, SettlementService } from './Services/ApiClientGenerated.service';
import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ExpenseDistributorSPA';
  userList:any[] = [];
  constructor( private userService:UserService, private expenseService:ExpenseService, private settlementService:SettlementService){
    this.userService.get(13).subscribe(response =>{
      console.log(response);
      }
    );
    this.userService.getlist().subscribe(response =>{
      console.log(response);
      }
    );
    this.settlementService.getListForUser(7).subscribe(response => console.log(response)
    );
  }
}
