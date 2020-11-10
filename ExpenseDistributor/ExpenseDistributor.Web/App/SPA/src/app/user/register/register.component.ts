import { NgForm } from '@angular/forms';
import { UserService, UserAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private userService:UserService,private router:Router) { }
  user:UserAC = new UserAC();
  name:string = null;
  email:string = null;
  password:string = null;
  phoneNumber:string = null;

  ngOnInit(): void {
  }

  Register(formData:NgForm){

    this.user.name = this.name;
    this.user.email = this.email;
    this.user.password = this.password;
    this.user.phoneNumber = this.phoneNumber;

    this.userService.postRegister(this.user).subscribe(response => {
      
    });
    this.router.navigate(['user/login']);
  }
}
