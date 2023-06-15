using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Models;
using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public class EquipeRepository : BaseRepository, IEquipeRepository
    {
        public EquipeRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Equipe>> ListAsync()
        {
            return await _context.Equipe.ToListAsync();
        }
        public async Task CadastrarEquipe(Equipe equipe)
        {
             _context.Equipe.AddAsync(equipe);
            await _context.SaveChangesAsync();
        }
        /*public async Task<Equipe> GetEquipeById(int id_equipe)
        {
            return await _context.Equipe.FirstOrDefaultAsync(e => e.id_equipe == id_equipe);
        }*/
        /*public async Task<Equipe> GetEquipeById(int id_equipe)
        {
            return await _context.Equipe.FindAsync(id_equipe);
        }*/
        public async Task<Equipe> GetEquipeById(int id_equipe)
        {
            return await _context.Equipe.FindAsync(id_equipe);
        }
}
}