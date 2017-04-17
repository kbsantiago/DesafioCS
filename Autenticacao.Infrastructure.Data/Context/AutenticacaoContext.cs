using Autenticacao.Domain.Entities;
using Autenticacao.Infrastructure.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace Autenticacao.Infrastructure.Data.Context
{
    public class AutenticacaoContext : DbContext
    {
        public AutenticacaoContext()
            : base("AutenticacaoDB")
        {

        }

        public IDbSet<Usuario> Usuarios { get; set; }
        public IDbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(30));

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new TelefoneConfiguration());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();           
        }

    }
}
