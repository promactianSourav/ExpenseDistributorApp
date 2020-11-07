import { UserService, LoginAC, ILoginAC } from './../../Services/ApiClientGenerated.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private userService:UserService,private router:Router) { }

  ngOnInit(): void {
  }
  errorMessage:string;
  email:string=null;
  password:string=null;
  readme:boolean=false;
  loginAC:LoginAC = new LoginAC();
  
  onSubmit(formData:NgForm){
    this.loginAC.email = this.email;
    this.loginAC.password = this.password;
    this.userService.postLogin(this.loginAC).subscribe(response =>{
        console.log(response);

        localStorage.setItem('Id',response.userId.toString());
    });
    
    // this.authservice.login(this.loginview).subscribe(
    //   response=>{console.log(response.status)},
    //   (error:any)=>this.errorMessage = <any> error
    // );
    
    // console.log(sessionStorage.getItem('token'));
    formData.resetForm();
    this.router.navigate(['user/groups']);
  }

}
