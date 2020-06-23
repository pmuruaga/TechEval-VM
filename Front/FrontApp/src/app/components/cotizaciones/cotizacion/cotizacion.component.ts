import { Component, OnInit, Input, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OperacionesService } from 'src/app/services/operaciones.service';
import { Cotizacion } from 'src/app/Interfaces';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-cotizacion',
  templateUrl: './cotizacion.component.html',
  styleUrls: ['./cotizacion.component.css']
})
export class CotizacionComponent implements OnInit {

  @Input() nombreMoneda: string;
  public cotizacion: Cotizacion;
  public showSpinner: boolean = true;

  constructor(http: HttpClient,
              protected operacionesService: OperacionesService) {
  }

  public GetCotizaciones() {
    console.log("GetCotizacion");
    this.operacionesService.GetCotizacion(this.nombreMoneda).subscribe(
      data => {
        this.cotizacion = data;
        console.log(data);
        this.showSpinner = false;
      },
      err => console.log(err)
  );
  }

  ngOnInit(): void {
    this.GetCotizaciones();
  }

  public ActualizaCotizaciones(){
    this.showSpinner = true;
    this.GetCotizaciones();
  }

}
