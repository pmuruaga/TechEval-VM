using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Monedas
{
    public class MonedaCotizacionDTO
    {
        public double PrecioVenta { get; set; }
        public double PrecioCompra { get; set; }
        public DateTime FechaActualizacion { get; set; }        
    }
}
