using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Repository
{
    public interface ICampeonatoRepository
    {
        Task<IEnumerable<Campeonato>> ListAsync();
        Task CadastrarCampeonato(Campeonato campeonato);
        Task<Campeonato> GetCampeonatoByName(string nome_campeonato);

    }
}