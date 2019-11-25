using Agenda.Domain.Dto;

namespace Agenda.Domain.Entities
{
  public class Contato : Entity
  {
    public Contato() { }

    public Contato(string nome, string canal, string valor, string observacoes)
    {
      Nome = nome;
      Canal = canal;
      Valor = valor;
      Observacoes = observacoes;
    }

    public string Nome { get; private set; }
    public string Canal { get; private set; }
    public string Valor { get; private set; }
    public string Observacoes { get; private set; }

    public Contato Converter(ContatoCreateOrUpdateDto contatoCreateOrUpdateDto)
    {
      this.Nome = contatoCreateOrUpdateDto.Nome;
      this.Canal = contatoCreateOrUpdateDto.Canal;
      this.Observacoes = contatoCreateOrUpdateDto.Observacoes;
      this.Valor = contatoCreateOrUpdateDto.Valor;

      return this;
    }
  }
}
