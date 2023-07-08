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
    
    public async Task<EquipeResponse> CadastrarEquipe(Equipe equipe){
        try
        {
            var existeEquipe = await _equipeRepository.GetEquipeByName(equipe.nome_equipe);
            if (existeEquipe != null)
            {
                return new EquipeResponse("Já existe uma equipe com esse nome.");
            }
            await _equipeRepository.CadastrarEquipe(equipe);
            return new EquipeResponse(equipe);
        }    
        catch (Exception ex)
            {
                return new EquipeResponse($"An error occurred when saving the product: {ex.Message}");
            }       
    }}
}