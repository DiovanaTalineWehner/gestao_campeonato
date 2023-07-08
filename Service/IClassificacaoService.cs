using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;
using gestao_campeonato.Service.Communication;

namespace gestao_campeonato.Service
{
    public interface IClassificacaoService
    {
        Task<IEnumerable<Classificacao>> ListAsync();

        Task<ClassificacaoResponse> CadastrarClassificacao(Classificacao classificacao);

    }
}