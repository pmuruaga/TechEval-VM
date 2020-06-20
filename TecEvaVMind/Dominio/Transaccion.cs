using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Transaccion
    {
        public Guid TransaccionId { get; set; }
        public DateTime FechaCompra { get; set; }
        public Guid MonedaId { get; set; }
        public Guid UsuarioId { get; set; }
        public double MontoCompra { get; set; }
    }
}
