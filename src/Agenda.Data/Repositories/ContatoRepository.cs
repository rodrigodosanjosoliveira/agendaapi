using Agenda.Data.Context;
using Agenda.Domain.Contracts.Repositories;
using Agenda.Domain.Entities;

namespace Agenda.Data.Repositories
{
  public class ContatoRepository : Repository<Contato>, IContatoRepository
  {
    public ContatoRepository(AgendaContext context)
        : base(context) { }
  }
}
