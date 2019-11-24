namespace Agenda.Domain.Dto {
    public class ContatoCreateOrUpdateDto {
        public System.Guid Id {get; set;}
        public string Nome { get; set; }
        public string Canal { get; set; }
        public string Valor { get; set; }
        public string Observacoes { get; set; }
        public string  Token { get; set; }
    }
}
