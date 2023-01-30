import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-registro-usuarios',
  templateUrl: './registro-usuarios.component.html',
  styleUrls: ['./registro-usuarios.component.css']
})
export class RegistroUsuariosComponent {
  registerForm: FormGroup
  constructor() {
    this.registerForm = new FormGroup({
      email: new FormControl(''),
      password: new FormControl(''),
      rol: new FormControl('')
    });
  }

  onSubmit() {
    const formData = this.registerForm.value;
    /** Validar seleccion del rol*/
    if(formData['rol'] ==""){
      alert('Se debe seleccionar un rol')
    }else{
      /**Implementar la llamada a la api */
    }

    // this.auth.login(this.loginForm.value)
    // .subscribe({
    //   next:(res)=>{        
    //   },
    //   error:(err)=>{
    //     console.log('la respuesta es :',err)
    //     //alert(err?.error.message)
    //   }
    // })


    console.log(formData);
  }
}
