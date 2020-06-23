import { Component, OnInit, Input, Inject } from '@angular/core';


@Component({
  selector: 'app-cotizaciones',
  templateUrl: './cotizaciones.component.html',
  styleUrls: ['./cotizaciones.component.css']
})
export class CotizacionesComponent implements OnInit {

  public lstMonedas: string[] = ["BRL","USD"];  

  constructor() {
  }

  ngOnInit(): void {
  }

}