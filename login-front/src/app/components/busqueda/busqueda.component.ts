import { Component, OnInit } from '@angular/core';
import { HttpClient ,HttpHeaders } from '@angular/common/http';
import { FilterPipe } from './filter.pipe';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LoginServiceService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-busqueda',
  templateUrl: './busqueda.component.html',
  styleUrls: ['./busqueda.component.css'],
  providers: [FilterPipe]
  
})
export class BusquedaComponent implements OnInit {
  rawData: any[] = [];
  myDataArray: any[] = [];
  searchText: string = "";
  startDate: Date;
  endDate: Date;

  

  constructor(private http: HttpClient,private route: ActivatedRoute,public auth: LoginServiceService) {
    
  }

  ngOnInit() {
    this.getData();
    //console.log(this.myDataArray)
    // if(this.auth.user.rol ==="Cliente"){
    //   this.myDataArray = this.rawData.filter(ap => ap.idEmpresa === this.auth.user.empresa)
    //   console.log(this.rawData)
    // }
  }

  getData() {
    // replace with the appropriate URL for your back-end API
    let headers = new HttpHeaders();
    headers = headers.append("Access-Control-Allow-Origin", "https://md-login.vercel.app");
    this.http.get('https://md-transporte-api.azurewebsites.net/api/Aplicaciones',{headers}).subscribe(data => {
      this.rawData = data as any[];
      this.myDataArray = this.rawData.filter(ap => ap.idEmpresa == this.auth.user.empresa)
    });
  }

  filterByDate() {

    // let formattedStartDate = new Date(this.startDate)//.toISOString().slice(0, 10);
    // let formattedEndDate = new Date(this.endDate)//.toISOString().slice(0, 10);
    let formattedStartDate = new Intl.DateTimeFormat("en-CA").format(new Date(this.startDate));
    let formattedEndDate = new Intl.DateTimeFormat("en-CA").format( new Date(this.endDate));
    console.log(formattedStartDate)
    console.log(formattedEndDate)
    //console.log(this.myDataArray[0].fecha)

    const date = new Date(this.myDataArray[0].fecha);
    const formattedDate = new Intl.DateTimeFormat("en-CA").format(date);

    console.log(formattedDate)
    if(this.startDate!==null && this.endDate!=null){
      if(this.startDate <= this.endDate){
        this.myDataArray = this.rawData.filter(item => {
        let date = new Date(item.fecha);
        let formattedDate = new Intl.DateTimeFormat("en-CA").format(date);
        return formattedDate > formattedStartDate && formattedDate < formattedEndDate;
        })
      }else{
        alert("Rango de fechas invalido")
      }
    }else{
      alert('Debes seleccionar un rango de fechas')
    }
  }

}
