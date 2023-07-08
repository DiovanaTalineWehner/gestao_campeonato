/*using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Service
{
    public class Local_CampeonatoService : ILocal_CampeonatoService
    {
       private readonly ILocal_CampeonatoRepository _local_campeonatoRepository;

        public Local_CampeonatoService(ILocal_CampeonatoRepository local_campeonatoRepository)
        {
            _local_campeonatoRepository = local_campeonatoRepository;
        }

        public async Task<IEnumerable<Local_Campeonato>> ListAsync()
        {
            return await _local_campeonatoRepository.ListAsync();
        }
        public async Task CadastrarLocal(Local_Campeonato local_campeonato)
        {
            await _local_campeonatoRepository.CadastrarLocal(local_campeonato);
        }
    }
}*/