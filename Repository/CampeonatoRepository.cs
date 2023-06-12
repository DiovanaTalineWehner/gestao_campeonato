using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Models;
using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public class CampeonatoRepository : BaseRepository, ICampeonatoRepository
    {
        public CampeonatoRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Campeonato>> ListAsync()
        {
            return await _context.Campeonato.ToListAsync();
        }
        public async Task CadastrarCampeonato(Campeonato campeonato)
        {
            await _context.Campeonato.AddAsync(campeonato);
            await _context.SaveChangesAsync();
        }
    }
}