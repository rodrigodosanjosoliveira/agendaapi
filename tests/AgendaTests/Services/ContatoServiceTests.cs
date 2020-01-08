using Agenda.Application.Services;
using Agenda.Data.Context;
using Agenda.Domain.Contracts.Repositories;
using Agenda.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AgendaTests.Services
{
    public class ContatoServiceTests
    {
        [Fact]
        public async Task Add_Contato_Database()
        {
            var mockRepository = new Mock<IContatoRepository>();
            var options = new DbContextOptionsBuilder<AgendaContext>()
                .UseInMemoryDatabase(databaseName: "agendadb_test")
                .Options;

            using (var context = new AgendaContext(options))
            {
                var service = new ContatoService(mockRepository.Object);
                _ = await service.Create(new ContatoCreateOrUpdateDto
                {
                    Canal = "telefone",
                    Nome = "Fulano",
                    Observacoes = "Teste",
                    Valor = "21979075829"
                });
            }

            using (var context = new AgendaContext(options))
            {
                Assert.Equal(1, await context.Contatos.CountAsync());
                Assert.Equal("telefone", context.Contatos.SingleAsync().Result.Canal);
            }
        }
    }
}
