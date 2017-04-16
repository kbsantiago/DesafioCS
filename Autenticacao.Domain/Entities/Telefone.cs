using System;

namespace Autenticacao.Domain.Entities
{
    public class Telefone
    {
        public Guid Id { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }

        public Telefone(string ddd, string numero)
        {
            Ddd = ddd;
            Numero = numero;

            Id = Guid.NewGuid();
        }

        protected Telefone() { }        
    }
}
