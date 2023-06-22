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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllLancamentos = new GetAllLancamento(query);

            var lancamentos = await _mediator.Send(getAllLancamentos);

            if (lancamentos.Count == 0)
                return BadRequest("Ooops! Ainda não existem lançamentos...");

            return Ok(lancamentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetLancamentoById(id);

            var result = await _mediator.Send(query);

            if (result is null)
                return BadRequest("Ooops! Lançamento não encontrado...");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddLancamento command)
        {
            var id = await _mediator.Send(command);

            if (id == null)
                return BadRequest("Ooops! Verifique as informações inseridas...");

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutLancamento command)
        {
            await _mediator.Send(command);

            if (id == null)
                return BadRequest("Ooops! Verifique as informações inseridas...");

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteId = new DeleteLancamento(id);

            await _mediator.Send(deleteId);

            if (id == null)
                return BadRequest("Ooops! Verifique as informações inseridas...");


            return NoContent();
        }
    }
}