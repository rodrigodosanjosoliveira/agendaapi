using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Agenda.Domain.Contracts.Services;
using Agenda.Domain.Dto;
using Agenda.Domain.Entities;
using Agenda.Domain.ValueTypes;

namespace Agenda.WebApi.Controllers
{
  [Route("api/[controller]")]
  [Produces(MediaTypeNames.Application.Json)]
  [ApiController]
  public class ContatosController : ControllerBase
  {
    private readonly IContatoService _contatoService;

    public ContatosController(IContatoService contatoService)
    {
      _contatoService = contatoService;
    }

    [HttpGet("{idContato}")]
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
  }
}
