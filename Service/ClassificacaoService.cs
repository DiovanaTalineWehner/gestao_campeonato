using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Service
{
    public class ClassificacaoService : IClassificacaoService
    {
        private readonly IClassificacaoRepository _classificacaoRepository;

        public ClassificacaoService(IClassificacaoRepository classificacaoRepository)
        {
            _classificacaoRepository = classificacaoRepository;
        }

        public async Task<IEnumerable<Classificacao>> ListAsync()
        {
            return await _classificacaoRepository.ListAsync();
        }
    }
}