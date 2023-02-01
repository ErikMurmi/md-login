import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient ,HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-registro-usuarios',
  templateUrl: './registro-usuarios.component.html',
  styleUrls: ['./registro-usuarios.component.css']
})
export class RegistroUsuariosComponent {


  registerForm: FormGroup
  optionsList: any;

  ngOnInit() {
    this.http.get('https://md-transporte-api.azurewebsites.net/api/Empresas')
        .subscribe(response => {
          console.log(response);
          this.optionsList = response
        });
  }

  constructor(private http: HttpClient) {
    this.registerForm = new FormGroup({
      nombre: new FormControl(''),
      apellido: new FormControl(''),
      email: new FormControl(''),
      password: new FormControl(''),
      idRol: new FormControl(''),
      idEmpresa: new FormControl('')
    });
  }

  onSubmit() {
    const formData = this.registerForm.value;
    /** Validar seleccion del rol*/
    if(formData['nombre'] ==""||formData['apellido'] ==""||formData['rol'] =="" || formData['empresa'] =="" || formData['email'] =="" || formData['password'] ==""){
      alert('Campos vacios revise la información')
    }else{
      /**Implementar la llamada a la api */
      console.log(formData);
      this.http.post('https://md-transporte-api.azurewebsites.net/api/Usuarios',formData).subscribe(response => {
        console.log(response);
        alert("Usuario agregado")
    });
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
