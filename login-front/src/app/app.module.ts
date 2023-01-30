import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { FormComponent } from './components/form/form.component';
import { BusquedaComponent } from './components/busqueda/busqueda.component';
import { FilterPipe } from './components/busqueda/filter.pipe';
import { AlertModule } from 'ngx-alerts';
import { SidebarModule } from '@syncfusion/ej2-angular-navigations';
import { RegistroUsuariosComponent } from './components/registro-usuarios/registro-usuarios.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    FormComponent,
    BusquedaComponent,
    FilterPipe,
    RegistroUsuariosComponent
    
  ],
  imports: [
    BrowserModule,
    SidebarModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    AlertModule.forRoot({maxMessages: 5, timeout: 5000}), 
    MatSidenavModule,
    MatListModule,
    RouterModule.forRoot([
      { path: 'form', component: FormComponent },
      { path: 'search', component: BusquedaComponent },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
