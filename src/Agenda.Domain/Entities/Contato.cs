﻿using Agenda.Domain.Dto;

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

        public void Converter(ContatoCreateOrUpdateDto contatoCreateOrUpdateDto)
        {
            Nome = contatoCreateOrUpdateDto.Nome;
            Canal = contatoCreateOrUpdateDto.Canal;
            Observacoes = contatoCreateOrUpdateDto.Observacoes;
            Valor = contatoCreateOrUpdateDto.Valor;
        }
    }
}
