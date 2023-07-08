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
        /*public async Task<Classificacao> GetClassificacaoByName(string nome_classificacao)
        {
            return await _context.Classificacao.FirstOrDefaultAsync(e => e.nome_classificacao == nome_classificacao);
        }*/
        public async Task CadastrarClassificacao(Classificacao classificacao)
        {
             _context.Classificacao.AddAsync(classificacao);
            await _context.SaveChangesAsync();
        }
    }
}