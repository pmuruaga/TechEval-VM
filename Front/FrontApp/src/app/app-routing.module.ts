import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CotizacionesComponent } from './components/cotizaciones/cotizaciones.component';
import { ComprarMonedaComponent } from './components/comprar-moneda/comprar-moneda.component';
import { AppComponent } from './app.component';


const routes: Routes = [  
  { path: 'cotizaciones', component: CotizacionesComponent },
  { path: 'compra', component: ComprarMonedaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
