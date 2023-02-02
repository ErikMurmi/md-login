import { Router } from '@angular/router';

import { Component, ViewChild } from '@angular/core';
import { LoginServiceService } from './services/login-service.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})



export class AppComponent {

  constructor(private router: Router, public auth: LoginServiceService) {}

  title = 'login-front';
  

}
