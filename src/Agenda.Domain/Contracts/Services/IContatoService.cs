using Agenda.Domain.Dto;
using Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda.Domain.Contracts.Services
{
  public interface IContatoService
  {
    Task<Contato> Create(ContatoCreateOrUpdateDto contato);
    Task Delete(Guid id);
    IEnumerable<Contato> GetAll();
    Task<Contato> GetById(Guid id);
    Task<Contato> Update(Guid id, ContatoCreateOrUpdateDto contato);
  }
}
