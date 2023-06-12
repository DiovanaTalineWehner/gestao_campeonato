using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Models;
using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public class Local_CampeonatoRepository : BaseRepository, ILocal_CampeonatoRepository
    {
        public Local_CampeonatoRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Local_Campeonato>> ListAsync()
        {
            return await _context.Local_Campeonato.ToListAsync();
        }
        public async Task CadastrarLocal(Local_Campeonato local_campeonato)
        {
            await _context.Local_Campeonato.AddAsync(local_campeonato);
            await _context.SaveChangesAsync();

        }
    }
}