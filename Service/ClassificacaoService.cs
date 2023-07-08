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
    public class ClassificacaoService : IClassificacaoService
    {   
        private readonly IEquipeRepository _EquipeRepository;
        private readonly IClassificacaoRepository _classificacaoRepository;

        public ClassificacaoService(IClassificacaoRepository classificacaoRepository, IEquipeRepository EquipeRepository)
        {
            _classificacaoRepository = classificacaoRepository;
            _EquipeRepository = EquipeRepository;
        }

        public async Task<IEnumerable<Classificacao>> ListAsync()
        {
            return await _classificacaoRepository.ListAsync();
        }

        public async Task<ClassificacaoResponse> CadastrarClassificacao(Classificacao classificacao)
        {
            try
            {
                var existeEquipe = await _EquipeRepository.GetEquipeById(classificacao.equipe.id_equipe);
                if(existeEquipe == null)
                {
                    return new ClassificacaoResponse("Invalid equipe.");
                }

                classificacao.equipe = existeEquipe;
                await _classificacaoRepository.CadastrarClassificacao(classificacao);

                return new ClassificacaoResponse(classificacao);
            }
            catch (Exception ex)
            {
                return new ClassificacaoResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }
    }
}