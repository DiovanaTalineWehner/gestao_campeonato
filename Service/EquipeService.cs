using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Service
{
    public class EquipeService : IEquipeService
    {
    private readonly IEquipeRepository _equipeRepository;

    public EquipeService(IEquipeRepository EquipeRepository)
        {
            _equipeRepository = EquipeRepository;
        }

    public async Task<IEnumerable<Equipe>> ListAsync()
        {
            return await _equipeRepository.ListAsync();
        }
    
    public async Task CadastrarEquipe(Equipe equipe)
        {
            await _equipeRepository.CadastrarEquipe(equipe);
        }
    }
}