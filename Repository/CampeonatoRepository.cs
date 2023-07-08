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
              _context.Campeonato.AddAsync(campeonato);
            await _context.SaveChangesAsync();
        }
        public async Task<Campeonato> GetCampeonatoByName(string nome_campeonato)
        {
            return await _context.Campeonato.FirstOrDefaultAsync(e => e.nome_campeonato == nome_campeonato);
        }
    }
}