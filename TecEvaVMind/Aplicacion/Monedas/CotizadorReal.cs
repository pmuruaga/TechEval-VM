using Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Monedas
{
    public class CotizadorReal : ICotizable
    {
        public async Task<MonedaCotizacionDTO> GetCotizacion()
        {
            //TODO Cambiar por el cotizador de Real que consume la api correcta.
            CotizadorDolar cotizadorDolar = new CotizadorDolar();
            Task<MonedaCotizacionDTO> monedaD = cotizadorDolar.GetCotizacion();
            
            MonedaCotizacionDTO monedaR = await monedaD;
            monedaR.PrecioVenta = monedaR.PrecioVenta / 4;
            monedaR.PrecioCompra = monedaR.PrecioCompra / 4;

            return monedaR;
        }
    }
}
