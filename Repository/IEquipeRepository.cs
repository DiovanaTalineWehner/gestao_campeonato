using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Repository
{
    public interface IEquipeRepository
    {
        Task<IEnumerable<Equipe>> ListAsync();
        Task CadastrarEquipe(Equipe equipe);
        Task<Equipe> GetEquipeById(int id_equipe);
        Task<Equipe> GetEquipeByName(string nome_equipe);


    }
}