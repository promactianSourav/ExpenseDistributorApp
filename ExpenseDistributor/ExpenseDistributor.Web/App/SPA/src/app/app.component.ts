import { UserService, ExpenseService, UserAC } from './Services/ApiClientGenerated.service';
import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ExpenseDistributorSPA';
  userList:any[] = [];
  constructor( private userService:UserService, private expenseService:ExpenseService){
    this.userService.getlist().subscribe(response =>{
      console.log(response);
      }
    );

    this.userService.check().subscribe(response => console.log(response)
    );
  }
}
