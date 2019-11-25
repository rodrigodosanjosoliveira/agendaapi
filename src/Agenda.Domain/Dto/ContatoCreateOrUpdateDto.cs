using System.Runtime.Serialization;

namespace Agenda.Domain.Dto
{
  [DataContract]
  public class ContatoCreateOrUpdateDto
  {
    public System.Guid Id { get; set; }
    [DataMember]
    public string Nome { get; set; }
    [DataMember]
    public string Canal { get; set; }
    [DataMember]
    public string Valor { get; set; }
    [DataMember]
    public string Observacoes { get; set; }
  }
}
