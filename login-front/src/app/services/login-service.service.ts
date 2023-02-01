import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  private base_url = 'https://localhost:7214/api/Usuarios'
  constructor(private http: HttpClient) { }
  login(loginObj : any){
    return this.http.post<any>(`${this.base_url}/Login`,loginObj)
  }
}
