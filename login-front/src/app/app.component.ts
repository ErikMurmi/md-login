import { Router } from '@angular/router';

import { Component, ViewChild } from '@angular/core';
import { SidebarComponent } from '@syncfusion/ej2-angular-navigations';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})



export class AppComponent {

  constructor(private router: Router) {}

  @ViewChild('sidebar')
    public sidebar: SidebarComponent;
    public width: string = '290px';
    public onCreated(args: any) {
         this.sidebar.element.style.visibility = '';
    }
    openClick(): void {
        this.sidebar.toggle();
    }

    navigateToForm() {
      this.router.navigate(['/form']);
    }
    //navigating to search
    navigateToSearch() {
      this.router.navigate(['/search']);
    }


  title = 'login-front';
  
  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateHome() {
    this.router.navigate(['/']);
  }
}
