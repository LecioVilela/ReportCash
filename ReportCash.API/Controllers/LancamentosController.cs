using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReportCash.Application.Commands;
using ReportCash.Application.Queries;

namespace ReportCash.API.Controllers
{
    [ApiController]
    [Route("api/lancamentos")]
    public class LancamentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LancamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }
// FALTA TERMINAR MAIS ENDPOINTS AQUI NESSA CONTROLLER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! OLHAR NA ProjectsController do DevFreela
        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllLancamentos = new GetAllLancamento(query);

            var lancamentos = await _mediator.Send(getAllLancamentos);

            return Ok(lancamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetLancamentoById(id);

            var result = await _mediator.Send(query);

            if (result is null)
                return NotFound("Ooops!");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddLancamento command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutLancamento command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteId = new DeleteLancamento(id);

            await _mediator.Send(deleteId);

            return NoContent();
        }
    }
}