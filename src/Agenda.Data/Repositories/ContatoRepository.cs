using Agenda.Data.Context;
using Agenda.Domain.Contracts.Repositories;
using Agenda.Domain.Entities;

namespace Agenda.Data.Repositories {
    public class UsuarioRepository : Repository<Contato>, IContatoRepository {
        public UsuarioRepository(AgendaContext context)
            : base(context) { }
    }
}
