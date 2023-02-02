import { Component } from '@angular/core';
import { LoginServiceService } from '../services/login-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  constructor(public auth: LoginServiceService, private router: Router) {}

  logout(){
    this.auth.logOut();
    this.router.navigate(['/login'])
  }
}
