using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Service
{
    public interface IClassificacaoService
    {
        Task<IEnumerable<Classificacao>> ListAsync();
    }
}