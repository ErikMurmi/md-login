import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent {
  
    constructor(private http: HttpClient) { }

    onSubmit(formData:any) {
        formData.value["Empresa"] = "Supermaxi"
        console.log(formData.value);
        this.http.post('https://apitransporte.azurewebsites.net/api/Aplicaciones/Crear', formData.value)
          .subscribe(response => {
            console.log(response);
            alert("Se agrega correctamente")
          });
      }
      
}
