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
        formData.value["MontoCompraApli"] = formData.value["MontoCompraApli"].toString()
        formData.value["BultosApli"] = formData.value["BultosApli"].toString()
        formData.value["SumaAseguradaApli"] = formData.value["SumaAseguradaApli"].toString()
        formData.value["TasaApli"] = formData.value["TasaApli"].toString()
        formData.value["PesoBrutoApli"] = formData.value["PesoBrutoApli"].toString()
        formData.value["GastosJustificadosApli"] = formData.value["GastosJustificadosApli"].toString()
        formData.value["TasaApli"] = formData.value["TasaApli"].toString()
        formData.value["ValorPrimaApli"] = formData.value["ValorPrimaApli"].toString()
        formData.value["DeducibleApli"] = formData.value["DeducibleApli"].toString()
        
        console.log(formData.value);
        this.http.post('https://apitransporte.azurewebsites.net/api/Aplicaciones/Crear', formData.value)
          .subscribe(response => {
            console.log(response);
            alert("Se agrega correctamente")
          });
      }
      
}
