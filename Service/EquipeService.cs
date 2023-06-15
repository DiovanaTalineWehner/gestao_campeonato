using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;
using gestao_campeonato.Service.Communication;
using gestao_campeonato.Service;
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