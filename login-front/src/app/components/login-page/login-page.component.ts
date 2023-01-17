import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { LoginServiceService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  loginForm: FormGroup;
  constructor(private auth: LoginServiceService){
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
        alert(res.message)
      },
      error:(err)=>{
        alert(err?.error.message)
      }
    })
    console.log(formData);
    // console.log(formData.password);
    // console.log(formData.currency);
    //llama al servicio de autenticacion
  }
}
