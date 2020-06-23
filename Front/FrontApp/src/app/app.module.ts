import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { CotizacionesComponent } from './components/cotizaciones/cotizaciones.component';
import { ComprarMonedaComponent } from './components/comprar-moneda/comprar-moneda.component';
import { CotizacionComponent } from './components/cotizaciones/cotizacion/cotizacion.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { OperacionesService } from './services/operaciones.service';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';

@NgModule({
  declarations: [
    AppComponent,
    CotizacionesComponent,
    ComprarMonedaComponent,
    CotizacionComponent,
    LoadingSpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ OperacionesService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
