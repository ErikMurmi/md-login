import { Injectable } from '@angular/core';
import { BehaviorSubject, map, tap } from 'rxjs';
import {HttpClient} from "@angular/common/http"
import { UserModel } from '../models/user.model';
import { Buffer } from 'buffer';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  private base_url = 'https://md-transporte-api.azurewebsites.net/api/Usuarios';
  private _isLoggedIn$ = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this._isLoggedIn$.asObservable();
  user!: UserModel;
  private readonly TOKEN_NAME = 'USER_TOKEN'

  get token():any{
    return localStorage.getItem(this.TOKEN_NAME)
  }

  constructor(private http: HttpClient) { 
    this._isLoggedIn$.next(!!this.token);
    if(this.token!==null)
      this.user = this.getUser(this.token);
  }

  login(loginObj : any){
    return this.http.post<any>(`${this.base_url}/Login`, loginObj).pipe(
      map(res => {
        this._isLoggedIn$.next(true);
        localStorage.setItem(this.TOKEN_NAME, res.token);
        this.user = this.getUser(res.token)
        return res;
      })
    );
  }

  logOut(){
    localStorage.removeItem(this.TOKEN_NAME);
    this._isLoggedIn$.next(false);
  }


  private getUser(token:string):UserModel{
    return JSON.parse(Buffer.from(token.split('.')[1], 'base64').toString('binary')) as UserModel;
  }

}
