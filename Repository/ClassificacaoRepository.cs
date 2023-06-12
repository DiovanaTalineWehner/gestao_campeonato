using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gestao_campeonato.Models;
using gestao_campeonato.Database;

namespace gestao_campeonato.Repository
{
    public class ClassificacaoRepository : BaseRepository, IClassificacaoRepository
    {
        public ClassificacaoRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Classificacao>> ListAsync()
        {
            return await _context.Classificacao.ToListAsync();
        }
    }
}