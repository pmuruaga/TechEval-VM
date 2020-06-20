using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Monedas
{
    public interface ICotizable
    {
        Task<MonedaCotizacionDTO> GetCotizacion();
    }
}
