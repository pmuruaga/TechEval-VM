using Aplicacion.Monedas;
using Aplicacion.ErrorHandler;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Transacciones
{
    public class ComprarMoneda
    {
        public class DatosCompra : IRequest
        {
            public Guid IdUsuario { get; set; }
            public double MontoEnPesos { get; set; }
            public string CodigoMoneda { get; set; }
        }

        public class Manejador : IRequestHandler<DatosCompra>
        {
            private readonly CotizacionesDbContext _context;
            private readonly IConfiguration _configuration;

            public Manejador(CotizacionesDbContext context, IConfiguration configuration)
            {
                _context = context;
                _configuration = configuration;
            }
            public async Task<Unit> Handle(DatosCompra request, CancellationToken cancellationToken)
            {
                CotizadorFactory cf = new CotizadorFactory();
                var cotizador = cf.GetCotizador(request.CodigoMoneda);
                var cotizacion = await cotizador.GetCotizacion();

                var moneda = await _context.Moneda.FirstOrDefaultAsync(i => i.CodigoMoneda == request.CodigoMoneda);
                if (moneda == null)
                {
                    throw new ExceptionHandler(HttpStatusCode.NotFound, new { mensaje = "Codigo de Moneda no Valido" });
                }
                
                var montoCompra = request.MontoEnPesos / ((MonedaCotizacionDTO)cotizacion).PrecioVenta;                
                
                var transaccion = new Transaccion
                {
                    TransaccionId = new Guid(),
                    FechaCompra = DateTime.Now,
                    UsuarioId = request.IdUsuario,
                    MonedaId = moneda.MonedaId,
                    MontoCompra = montoCompra
                };

                var valor = 0;
                TransaccionValidator validador = new TransaccionValidator(_configuration, _context);                
                if (validador.Validar(transaccion, moneda))
                {                    
                    _context.Transaccion.Add(transaccion);
                    valor = await _context.SaveChangesAsync();
                }
                else {
                    throw new ExceptionHandler(HttpStatusCode.Forbidden, new { mensaje = "Transacción no válida. Alcanzó el limite mensual." });
                }
                
                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Fallo al grabar la transacción");
            }
        }
    }
}
