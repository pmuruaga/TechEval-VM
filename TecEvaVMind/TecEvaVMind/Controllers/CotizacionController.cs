using Aplicacion.Monedas;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecEvaVMind.Controllers
{
    //http://localhost:5000/api/Cotizacion
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CotizacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //http://localhost:5000/api/Cotizacion/USD
        [HttpGet("{codigoMoneda}")]
        public async Task<ActionResult<MonedaCotizacionDTO>> Detalle(string codigoMoneda)
        {
            return await _mediator.Send(new ConsultarCotizacion.CotizacionMoneda { CodigoMoneda = codigoMoneda });
        }
    }
}
