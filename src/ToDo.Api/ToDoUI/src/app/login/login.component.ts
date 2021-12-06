import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: User = new User();

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void { }

  login(form: NgForm){
    this.accountService.login(this.user).subscribe((data: any) => {
      localStorage.setItem('token', data.data.jwToken);
      this.router.navigateByUrl('/todo');
    })
  }

}
