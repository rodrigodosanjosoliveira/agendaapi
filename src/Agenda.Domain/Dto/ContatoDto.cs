using Agenda.Domain.Entities;

namespace Agenda.Domain.Dto
{
  public class ContatoDto
  {
    public System.Guid Id { get; set; }
    public string Nome { get; set; }
    public string Canal { get; set; }
    public string Valor { get; set; }
    public string Observacoes { get; set; }

    public ContatoDto(Contato contato)
    {
      Id = contato.Id;
      Nome = contato.Nome;
      Canal = contato.Canal;
      Valor = contato.Valor;
      Observacoes = contato.Observacoes;
    }
  }
}
