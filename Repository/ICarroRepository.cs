using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Repository
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> ListAsync();
        Task<Carro> GetCarro(int id);
        Task CadastrarCarro(Carro carro);
        Task DeleteCarro(Carro carro);
        Task<Carro> GetCarroByName(string nome_carro);

    }
}