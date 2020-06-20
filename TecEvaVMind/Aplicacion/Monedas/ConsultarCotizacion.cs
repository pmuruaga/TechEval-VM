using MediatR;
using Dominio;
using Persistencia;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Aplicacion.ErrorHandler;
using System.Net;

namespace Aplicacion.Monedas
{
    public class ConsultarCotizacion
    {
        public class CotizacionMoneda : IRequest<MonedaCotizacionDTO>
        {
            public string CodigoMoneda { get; set; }            
        }

        public class Manejador : IRequestHandler<CotizacionMoneda, MonedaCotizacionDTO>
        {
            private readonly CotizacionesDbContext _context;

            public Manejador(CotizacionesDbContext context)
            {
                _context = context;
            }
            public async Task<MonedaCotizacionDTO> Handle(CotizacionMoneda request, CancellationToken cancellationToken)
            {
                CotizadorFactory cf = new CotizadorFactory();
                var cotizador = cf.GetCotizador(request.CodigoMoneda);

                if(cotizador == null)
                    throw new ExceptionHandler(HttpStatusCode.NotFound, new { mensaje = "Codigo de Moneda no Valido" });                    

                var cotizacion = cotizador.GetCotizacion();
                
                return await cotizacion;
            }
        }
    }
}
