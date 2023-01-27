import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent {
  
    constructor(private http: HttpClient) { }

    form = new FormGroup({
      name: new FormControl('', Validators.required)
    });

    onSubmit(formData:any) {

      if (!formData.value["noApli"] || !formData.value["FechaApli"] || !formData.value["AseguradoApli"]
      || !formData.value["EmbarcadoPorApli"]  || !formData.value["BultosApli"] || !formData.value["pagadorApli"]
      || !formData.value["NotaPedidoApli"] || !formData.value["MontoCompraApli"] || !formData.value["DesdeApli"]
      || !formData.value["OrdenCompraApli"] || !formData.value["GastosJustificadosApli"]
      || !formData.value["HastaApli"] || !formData.value["AfianzadorAduanaApli"] || !formData.value["SumaAseguradaApli"]
      || !formData.value["TipoTransporApli"]|| !formData.value["IncotermsApli"]|| !formData.value["TasaApli"]
      || !formData.value["PertenecienteApli"]|| !formData.value["ItemsApli"]|| !formData.value["ValorPrimaApli"]
      || !formData.value["FechaEmbarqueApli"]|| !formData.value["Marca"]|| !formData.value["CoberturaApli"]
      || !formData.value["ConsiganadaApli"]|| !formData.value["NOApli"]|| !formData.value["DeducibleApli"]
      || !formData.value["FechaLlegadaApli"]|| !formData.value["PesoBrutoApli"]|| !formData.value["ObjetoSeguroApli"]
      || !formData.value["DescripcionApli"]|| !formData.value["ObservacionesApli"]) {
        
        alert("Hay campos vacíos, por favor llenarlos");
      } else {
        console.log("Campos llenos");
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
      
}
