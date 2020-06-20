using Aplicacion.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Monedas
{
    public class CotizadorDolar : ICotizable
    {
        public async Task<MonedaCotizacionDTO> GetCotizacion()
        {

            string urlDolar = "https://www.bancoprovincia.com.ar/Principal/Dolar";
            WebHelper webHelper = new WebHelper(urlDolar);
            string cotizacionDolar = await webHelper.GetResponse();

            //La respuesta que devuelve la api del banco no es un json, sino un string con formato de array.
            string[] dolar = cotizacionDolar.Trim('[',']').Split(",");            

            var moneda = new MonedaCotizacionDTO
            {
                PrecioCompra = double.Parse(dolar[0].Trim('"'), CultureInfo.InvariantCulture),
                PrecioVenta = double.Parse(dolar[1].Trim('"'), CultureInfo.InvariantCulture),
                FechaActualizacion = Convert.ToDateTime(dolar[2].Trim('"').Remove(0,14))
            };
            return moneda;
        }
    }
}
