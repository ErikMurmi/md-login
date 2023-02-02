import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoginServiceService } from 'src/app/services/login-service.service';
import { Router } from '@angular/router';
import { Buffer } from 'buffer';
import * as jwt_decode from "jwt-decode";
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
  user = {"empresa":""}

  constructor(private auth: LoginServiceService, private router: Router){
    this.loginForm = new FormGroup({
      Email: new FormControl(''),
      Password: new FormControl(''),
      currency: new FormControl('')
    });
  }

  onSubmit() {
    const formData = this.loginForm.value;
    this.auth.login(this.loginForm.value).subscribe({
      next:(res)=>{
        //alert(res.message)
        this.user = res
        console.log('info del token es :',JSON.parse(Buffer.from(res.token.split('.')[1], 'base64').toString('binary')))


        if(res.rol === "Administrador"){
          this.navigateToAdmin()
        }

        if(res.rol ==="Cliente"){
          this.navigateToCliente()
        }

        if(res.rol ==="Ejecutivo"){
          this.navigateToEjecutivo()
        }

        // if(this.user === "Administrador"){

        // }
        
      },
      error:(err)=>{
        console.log('la respuesta es :',err)
        alert('Usuario no encontrado revisa las credenciales')
      }
    })
    console.log(formData);
    // console.log(formData.password);
    // console.log(formData.currency);
    //llama al servicio de autenticacion
  }

  navigateToEjecutivo() {
    this.router.navigate(['/buscar']);

  }

  navigateToCliente() {
    this.router.navigate(['/form']);
  }

  navigateToAdmin() {
    this.router.navigate(['/registro']);
  }
}
