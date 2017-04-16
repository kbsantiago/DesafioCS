namespace Autenticacao.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Ddd = c.String(maxLength: 2, unicode: false),
                        Numero = c.String(maxLength: 10, unicode: false),
                        Usuario_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 250, unicode: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        DataUltimoLogin = c.DateTime(nullable: false),
                        Token = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Telefone", new[] { "Usuario_Id" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Telefone");
        }
    }
}
