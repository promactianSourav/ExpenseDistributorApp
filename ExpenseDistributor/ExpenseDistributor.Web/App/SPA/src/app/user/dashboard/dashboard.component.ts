import { FriendService, DashboardTotalAC, OweOrOwedAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private friendService:FriendService) { }

  dashboardTotal:DashboardTotalAC = new DashboardTotalAC();
  dashboardDetailsList:OweOrOwedAC[] = [];
  dashboardDetailsListOwe:OweOrOwedAC[] = [];
  dashboardDetailsListOwed:OweOrOwedAC[] = [];
  dashboardTotalNet:string = "";
  userId:number = Number(localStorage.getItem('Id'));
  friendId:number = Number(localStorage.getItem('friendId'));
  ngOnInit(): void {

    this.userId = Number(localStorage.getItem('Id'));
    this.friendId = Number(localStorage.getItem('friendId'));
    this.friendService.getDashboardDetails(this.userId).subscribe(response =>{
      this.dashboardDetailsList = response;
      // console.log(this.dashboardDetailsList);
      
      response.forEach(element => {
        if(element.oweOrOwedId == 1){
          this.dashboardDetailsListOwed.push(element);
        }else{
          this.dashboardDetailsListOwe.push(element);
        }
      });
    });

    this.friendService.getDashboardTotals(this.userId).subscribe(response => {
      this.dashboardTotal = response;
      // console.log(this.dashboardTotal);
      
      if(response.oweAmount>response.owedAmount){
        this.dashboardTotalNet = `-${response.oweAmount-response.owedAmount}`;
      }else{
        this.dashboardTotalNet = `+${response.owedAmount-response.oweAmount}`;
      }
    });
  }

}
