using Autenticacao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Autenticacao.Infrastructure.Data.EntityConfig
{
    public class TelefoneConfiguration : EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Ddd)
               .HasMaxLength(2);

            Property(c => c.Numero)
               .HasMaxLength(10);
        }
    }
}
