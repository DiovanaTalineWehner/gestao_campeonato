using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Repository
{
    public interface IClassificacaoRepository
    {
        Task<IEnumerable<Classificacao>> ListAsync();
    }
}