import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {

  userId:number;
  friendId:number;
   getuserIdData(){
    return this.userId;
  }
   setuserIdData(value:number){
    this.userId = value;
  }

   getfriendIdData(){
    return this.friendId;
  }
   setfriendIdData(value:number){
    this.friendId = value;
  }
  constructor() { }

}
