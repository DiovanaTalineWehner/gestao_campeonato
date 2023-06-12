using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Service
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly ICampeonatoRepository _campeonatoRepository;

        public CampeonatoService(ICampeonatoRepository campeonatoRepository)
        {
            _campeonatoRepository = campeonatoRepository;
        }

        public async Task<IEnumerable<Campeonato>> ListAsync()
        {
            return await _campeonatoRepository.ListAsync();
        }
        public async Task CadastrarCampeonato(Campeonato campeonato)
        {
            await _campeonatoRepository.CadastrarCampeonato(campeonato);
        }
    }
}