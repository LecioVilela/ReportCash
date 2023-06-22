using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReportCash.Application.Queries;

namespace ReportCash.API.Controllers
{
    [ApiController]
    [Route("api/relatorios")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RelatoriosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRelatorio(string query)
        {
            var getRelatorio = new GetRelatorio(query);

            var relatorios = await _mediator.Send(getRelatorio);

            return Ok(relatorios);
        }
    }
}