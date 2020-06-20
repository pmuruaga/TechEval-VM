using Aplicacion.Monedas;
using Aplicacion.Transacciones;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecEvaVMind.Controllers
{
    //http://localhost:5000/api/Transacciones
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransaccionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //http://localhost:5000/api/Transacciones       
        [HttpPost]
        public async Task<ActionResult<Unit>> Compra(ComprarMoneda.DatosCompra data)
        {
            return await _mediator.Send(data);
        }
    }
}
