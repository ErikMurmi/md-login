import { Component } from '@angular/core';
import { HttpClient ,HttpHeaders } from '@angular/common/http';
import { FilterPipe } from './filter.pipe';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-busqueda',
  templateUrl: './busqueda.component.html',
  styleUrls: ['./busqueda.component.css'],
  providers: [FilterPipe]
  
})
export class BusquedaComponent {
  myDataArray: any[] = [];
  searchText: string = "";

  

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    // replace with the appropriate URL for your back-end API
    let headers = new HttpHeaders();
    headers = headers.append("Access-Control-Allow-Origin", "https://md-login.vercel.app");
    this.http.get('https://md-transporte-api.azurewebsites.net/api/Aplicaciones',{headers}).subscribe(data => {
      this.myDataArray = data as any[];
    });
  }
}
