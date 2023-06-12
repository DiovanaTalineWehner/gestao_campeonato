using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;
using gestao_campeonato.Service.Communication;

namespace gestao_campeonato.Service
{
    public interface ICarroService
    {
        Task<IEnumerable<Carro>> ListAsync();
        Task<Carro> GetCarro(int id);
        Task<CarroResponse> CadastrarCarro(Carro carro);
        Task<CarroResponse> DeleteCarro(int id);
    }
}