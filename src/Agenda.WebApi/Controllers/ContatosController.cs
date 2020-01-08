using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Agenda.Domain.Contracts.Services;
using Agenda.Domain.Dto;
using Agenda.Domain.Entities;
using Agenda.Domain.ValueTypes;
using System.Collections.Generic;

namespace Agenda.WebApi.Controllers
{
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatosController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<ContatoDto> GetAll()
        {
            var contatos = _contatoService.GetAll();
            return ContatoDto.Convert(contatos);
        }

        [HttpGet("{idContato}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContatoDto>> Get(Guid idContato)
        {
            Erro erro = null;

            if (idContato == Guid.Empty)
            {
                erro = new Erro
                {
                    Mensagem = "Parâmetro inválido",
                    StatusCode = "400"
                };
                return BadRequest(erro);
            }

            var contato = await _contatoService.GetById(idContato);

            if (contato == null)
            {
                erro = new Erro
                {
                    Mensagem = "Contato não encontrado",
                    StatusCode = "404"
                };
                return NotFound(erro);
            }

            return Ok(new ContatoDto(contato));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ContatoDto>> Post([FromBody] ContatoCreateOrUpdateDto contatoCreateOrUpdateDto)
        {
            if (contatoCreateOrUpdateDto == null)
                return BadRequest(new Erro
                {
                    Mensagem = "Parâmetros inválidos",
                    StatusCode = "400"
                });

            Contato novoContato = await _contatoService.Create(contatoCreateOrUpdateDto);

            return CreatedAtAction(nameof(Get), new { idContato = novoContato.Id }, new ContatoDto(novoContato));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid idContato)
        {
            if (idContato == Guid.Empty)
                return BadRequest();

            Contato contato = await _contatoService.GetById(idContato);
            if (contato != null)
            {
                await _contatoService.Delete(idContato);
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("idContato")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid idContato, [FromBody] ContatoCreateOrUpdateDto contato)
        {
            if (idContato == Guid.Empty)
                return BadRequest();

            try
            {
                await _contatoService.Update(idContato, contato);
            }
            catch
            {
                if (_contatoService.GetById(idContato) == null)
                    return NotFound();
            }

            return NoContent();

        }

    }

}