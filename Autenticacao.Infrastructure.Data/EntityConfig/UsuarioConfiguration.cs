using Autenticacao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Autenticacao.Infrastructure.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Senha)
               .IsRequired()
               .HasMaxLength(250);

           Property(c => c.Token)
               .IsRequired()
               .HasMaxLength(250);
        }
    }
}
