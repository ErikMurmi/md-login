import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-busqueda',
  templateUrl: './busqueda.component.html',
  styleUrls: ['./busqueda.component.css']
})
export class BusquedaComponent {
  myDataArray: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    // replace with the appropriate URL for your back-end API
    this.http.get('http://domenicar16-001-site1.atempurl.com/api/Aplicaciones/Listar').subscribe(data => {
      this.myDataArray = data as any[];
    });
  }
}