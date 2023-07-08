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
        public async Task<CampeonatoResponse> CadastrarCampeonato(Campeonato campeonato)
        {
            try
            {
                var existeCampeonato = await _campeonatoRepository.GetCampeonatoByName(campeonato.nome_campeonato);
                if (existeCampeonato != null)
                {
                    return new CampeonatoResponse("Já existe um campeonato com esse nome.");
                }
                await _campeonatoRepository.CadastrarCampeonato(campeonato);
                return new CampeonatoResponse(campeonato);
            }

            catch (Exception ex)
            {
                return new CampeonatoResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }
    }
}