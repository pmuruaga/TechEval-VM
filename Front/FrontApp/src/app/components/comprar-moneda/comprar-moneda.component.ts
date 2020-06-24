import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { OperacionesService } from 'src/app/services/operaciones.service';


@Component({
  selector: 'app-comprar-moneda',
  templateUrl: './comprar-moneda.component.html',
  styleUrls: ['./comprar-moneda.component.css']
})
export class ComprarMonedaComponent implements OnInit {

  userIdControl = new FormControl('');
  monedaControl = new FormControl('');
  montoControl = new FormControl('');

  showSpinner: boolean = true;

  mensajeResultado: string = '';

  constructor(protected operacionesService: OperacionesService) { 
    
  }

  ngOnInit(): void {
    this.showSpinner = false;
  }


  public ComprarDiviza() {
    console.log("mostrar");
    this.showSpinner = true;
    this.operacionesService.Comprar(this.userIdControl.value, this.montoControl.value, this.monedaControl.value)
    .subscribe(
      data => {
        console.log(data);
        this.showSpinner = false;
        this.mensajeResultado = "Transacción Realizada";
      },
      err => {
        console.log(err);
        this.showSpinner = false;
        this.mensajeResultado = "Fallo la Compra";
      }
    );

    this.userIdControl.setValue('');
    //this.monedaControl.setValue('');
    //this.montoControl.setValue('');
    //this.text.nativeElement.focus();
  }

}
