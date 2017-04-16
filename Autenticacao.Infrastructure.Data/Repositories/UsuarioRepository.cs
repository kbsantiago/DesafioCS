using Autenticacao.Domain.Entities;
using Autenticacao.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autenticacao.Infrastructure.Data.Context;
using Autenticacao.Domain.Interfaces.Repositories;

namespace Autenticacao.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly AutenticacaoContext _context;

        public UsuarioRepository(AutenticacaoContext context) 
            : base(context)
        {
            _context = context;
        }

        public bool VerificarEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool VerificarEmailESenha(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
