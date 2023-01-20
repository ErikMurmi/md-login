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
      
        console.log(formData.value);
        this.http.post('http://domenicar16-001-site1.atempurl.com/api/Aplicaciones/Crear', formData.value)
          .subscribe(response => {
            console.log(response);
          });
      }
      
}
