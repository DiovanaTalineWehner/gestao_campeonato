using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;
using gestao_campeonato.Service.Communication;

namespace gestao_campeonato.Service
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ListAsync();
        Task<Usuario> GetUsuarioByEmail(string email_usuario);
        bool CheckPasswordAsync(Usuario user, string password);
      //  Task CadastrarUsuario(Usuario usuario);
        Task<UsuarioResponse> CadastrarUsuario(Usuario usuario);


    }
}