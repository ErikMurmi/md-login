import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent {
  
    constructor(private http: HttpClient, private router: Router) { }

    form = new FormGroup({
      name: new FormControl('', Validators.required)
    });

    onSubmit(formData:any) {

      console.log(formData.value);
      formData.value["estado"] = "Creada"
      formData.value["idEmpresa"] = 1
      if (!formData.value["numeroAplicacion"] || !formData.value["Fecha"] || 
      !formData.value["Asegurado"] || !formData.value["pagador"] || 
      !formData.value["Desde"] || !formData.value["Hasta"] || 
      !formData.value["TipoTransporte"] || !formData.value["Perteneciente"] ||
      !formData.value["FechaEmbarque"] || !formData.value["Consignada"] ||
      !formData.value["FechaLlegada"] || !formData.value["EmbarcadoPor"] ||
      !formData.value["NotaPedido"] || !formData.value["Incoterms"] ||
      !formData.value["OrdenCompra"] || !formData.value["AfianzadorAduana"] ||
      !formData.value["Items"] || !formData.value["Marca"] ||
      !formData.value["no"] || !formData.value["PesoBruto"] || !formData.value["Bultos"] || 
      !formData.value["MontoCompra"] || !formData.value["GastosJustificados"] ||
      !formData.value["SumaAsegurada"] || !formData.value["ValorPrima"] ||
      !formData.value["Tasa"] || !formData.value["Descripcion"] ||
      !formData.value["Observaciones"] || !formData.value["Cobertura"] ||
      !formData.value["Deducible"] || !formData.value["ObjetoSeguro"]
      ) {
        
        alert("Hay campos vacíos, por favor llenarlos");
      } else {
        console.log("Campos llenos");
        //formData.value["Empresa"] = 1
        /*formData.value["MontoCompra"] = formData.value["MontoCompra"].toString()
        formData.value["Bultos"] = formData.value["Bultos"].toString()
        formData.value["SumaAsegurada"] = formData.value["SumaAsegurada"].toString()
        formData.value["Tasa"] = formData.value["Tasa"].toString()
        formData.value["PesoBruto"] = formData.value["PesoBruto"].toString()
        formData.value["GastosJustificados"] = formData.value["GastosJustificados"].toString()
        formData.value["Tasa"] = formData.value["Tasa"].toString()
        formData.value["ValorPrima"] = formData.value["ValorPrima"].toString()
        formData.value["Deducible"] = formData.value["Deducible"].toString()*/
        
        console.log(formData.value);
        // this.http.post('https://md-transporte-api.azurewebsites.net/api/Aplicaciones', formData.value)
        //   .subscribe(response => {
        //     console.log(response);
        //     alert("Se agrega correctamente")
        //   });
        
        this.http.post('https://localhost:7214/api/Aplicaciones', formData.value)
        .subscribe(response => {
          console.log(response);
          alert("Se agrega correctamente")
        });
      }

        
      }
      
}
