import { FormComponent } from './components/form/form.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { BusquedaComponent } from './components/busqueda/busqueda.component';
import {RegistroUsuariosComponent} from './components/registro-usuarios/registro-usuarios.component'

const routes: Routes = [
{path:'login',component:LoginPageComponent},
{path:'form',component:FormComponent}
,{path:'buscar',component:BusquedaComponent},
{path:'registro',component:RegistroUsuariosComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
