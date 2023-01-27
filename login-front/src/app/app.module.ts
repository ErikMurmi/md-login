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


@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    FormComponent,
    BusquedaComponent,
    FilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
