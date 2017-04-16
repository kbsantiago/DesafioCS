using System;
using System.Collections.Generic;

namespace Autenticacao.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public List<Telefone> Telefones { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public DateTime DataUltimoLogin { get; private set; }
        public string Token { get; private set; }

        public Usuario(string nome, string email, string senha, List<Telefone> telefones, string token)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefones = telefones;
            Token = token;

            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            DataUltimoLogin = DateTime.Now;
        }

        public void AtualizarDataUltimoLogin()
        {
            DataUltimoLogin = DateTime.Now;
        }

        protected Usuario() { }
    }
}
