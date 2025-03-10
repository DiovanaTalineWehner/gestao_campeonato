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
    public class CarroService : ICarroService
        {
        private readonly IEquipeRepository _EquipeRepository;
        private readonly ICarroRepository _CarroRepository;

        public CarroService(ICarroRepository CarroRepository, IEquipeRepository EquipeRepository)
        {
            _CarroRepository = CarroRepository;
            _EquipeRepository = EquipeRepository;

        }

        public async Task<IEnumerable<Carro>> ListAsync()
        {
            return await _CarroRepository.ListAsync();
        }

        public async Task<Carro> GetCarro(int id)
        {
            return await _CarroRepository.GetCarro(id);
        }

        public async Task<CarroResponse> CadastrarCarro(Carro carro)
        {
            try
            {
                var existingEquipe = await _EquipeRepository.GetEquipeById(carro.equipe.id_equipe);
                if (existingEquipe == null)
                {
                    return new CarroResponse("Invalid equipe.");
                }
            
                carro.equipe = existingEquipe;

                var existingCarro = await _CarroRepository.GetCarroByName(carro.nome_carro);
                if (existingCarro != null)
                {
                    return new CarroResponse("Já existe um carro com esse nome.");
                }
                await _CarroRepository.CadastrarCarro(carro);

                return new CarroResponse(new Carro());
            }
            catch (Exception ex)
            {
                return new CarroResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<CarroResponse> DeleteCarro(int id)
        {
            try
            {
                var carroToDelete = await _CarroRepository.GetCarro(id);

                if(carroToDelete == null)
                {
                    return new CarroResponse("Carro não encontrado.");
                }
                await _CarroRepository.DeleteCarro(carroToDelete);
                return new CarroResponse(carroToDelete);
            }
            catch (Exception e)
            {
                return new CarroResponse($"Ocorreu um erro ao deletar Carro: {e.Message}");
            }
        }

    }
}