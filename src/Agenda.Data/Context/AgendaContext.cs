using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext() { }

        public AgendaContext(DbContextOptions options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AgendaDb;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Contato>(
                p =>
                {
                    p.HasKey("Id");
                    p.Property(e => e.Nome);
                    p.Property(e => e.Canal);
                    p.Property(e => e.Valor);
                    p.Property(e => e.Observacoes);
                }
            );

        }
    }
}
