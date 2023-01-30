import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoginServiceService } from 'src/app/services/login-service.service';
import { Router } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';
// import { AlertsService } from 'ngx-alerts';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  loginForm: FormGroup;
  user = {}

  constructor(private auth: LoginServiceService, private router: Router){
    this.loginForm = new FormGroup({
      EmailUsuario: new FormControl(''),
      PasswordUsuario: new FormControl(''),
      currency: new FormControl('')
    });
  }

  onSubmit() {
    const formData = this.loginForm.value;
    this.auth.login(this.loginForm.value)
    .subscribe({
      next:(res)=>{
        //alert(res.message)
        console.log('la respuesta es :',res)
        this.user = res

        if(res.rol === "Administrador"){
          this.navigateToAdmin()
        }

        if(res.rol ==="Usuarios"){
          this.navigateToFybeca()
        }

        // if(this.user === "Administrador"){

        // }
        
      },
      error:(err)=>{
        console.log('la respuesta es :',err)
        //alert(err?.error.message)
      }
    })
    console.log(formData);
    // console.log(formData.password);
    // console.log(formData.currency);
    //llama al servicio de autenticacion
  }


  

  navigateToSupermaxi() {
    this.router.navigate(['/form']);
  }

  navigateToFybeca() {
    this.router.navigate(['/form']);
  }

  navigateToAdmin() {
    this.router.navigate(['/buscar']);
  }
}
