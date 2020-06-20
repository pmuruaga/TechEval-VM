using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Monedas
{
    public class CotizadorFactory : ICotizadorFactory
    {
        public ICotizable GetCotizador(string codigoMoneda)
        {
            codigoMoneda = codigoMoneda.ToUpper();
            //TODO Cambiar la forma que selecciona, asigna el cotizador.
            switch (codigoMoneda) {
                case "USD":
                    return new CotizadorDolar();
                case "BRL":
                    return new CotizadorReal();
                default:
                    return null;
            }
        }
    }
}
