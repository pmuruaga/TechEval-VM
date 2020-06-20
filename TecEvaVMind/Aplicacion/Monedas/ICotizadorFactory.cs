using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Monedas
{
    public interface ICotizadorFactory
    {
        ICotizable GetCotizador(string codigoMoneda);
    }
}
