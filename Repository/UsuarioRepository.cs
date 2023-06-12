using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Models;
using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _context.Usuario.ToListAsync();
        }
         public async Task CadastrarUsuario(Usuario usuario)
        {
            _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
    }
}