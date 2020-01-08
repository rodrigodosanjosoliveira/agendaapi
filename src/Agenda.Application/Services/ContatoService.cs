using System.Threading.Tasks;
using Agenda.Domain.Contracts.Repositories;
using Agenda.Domain.Contracts.Services;
using Agenda.Domain.Dto;
using Agenda.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Agenda.Application.Services
{
  public class ContatoService : IContatoService
  {
    private readonly IContatoRepository _contatoRepository;

    public ContatoService(IContatoRepository contatoRepository)
    {
      _contatoRepository = contatoRepository;
    }

    public async Task<Contato> Create(ContatoCreateOrUpdateDto contato)
    {
      var contatoToCreate = new Contato(
                          contato.Nome,
                          contato.Canal,
                          contato.Valor,
                          contato.Observacoes);
      Contato novoContato = await _contatoRepository.Create(contatoToCreate);
      return novoContato;
    }

    public async Task Delete(Guid id)
    {
      await _contatoRepository.Delete(id);
    }

    public IEnumerable<Contato> GetAll()
    {
      var Contatos = _contatoRepository.GetAll();

      return Contatos;
    }

    public async Task<Contato> GetById(Guid id)
    {
      return await _contatoRepository.GetById(id);
    }

    public async Task<Contato> Update(Guid id, ContatoCreateOrUpdateDto contato)
    {
      var contatoDb = await GetById(id);
      contatoDb.Converter(contato);
      return await _contatoRepository.Update(id, contatoDb);
    }
  }
}