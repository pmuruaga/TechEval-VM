using Dominio;
using Microsoft.Extensions.Configuration;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Aplicacion.Transacciones
{
    public class TransaccionValidator
    {
        private readonly IConfiguration _configuration;
        private readonly CotizacionesDbContext _context;
        public TransaccionValidator(IConfiguration configuration, CotizacionesDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public bool Validar(Transaccion transaccion, Moneda moneda)
        {            
            var operacionesMes = _context.Transaccion.Where(x => x.MonedaId == transaccion.MonedaId && x.UsuarioId == transaccion.UsuarioId && x.FechaCompra.Month == transaccion.FechaCompra.Month);

            var totalComprasMes = operacionesMes.Sum(x => x.MontoCompra);

            double limiteCompra = double.Parse(_configuration[$"Limites:{moneda.CodigoMoneda}"]);
            if (limiteCompra > transaccion.MontoCompra + totalComprasMes)
                return true;
            else
                return false;
        }
    }
}
