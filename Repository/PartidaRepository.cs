/*using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Models;
using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public class PartidaRepository : BaseRepository, IPartidaRepository
    {
        public PartidaRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Partida>> ListAsync()
        {
            return await _context.Partida.ToListAsync();
        }
    }
}*/