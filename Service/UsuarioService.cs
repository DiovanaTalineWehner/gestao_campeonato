using System.Collections.Generic;
using System.Threading.Tasks;
using gestao_campeonato.Models;
using gestao_campeonato.Repository;

namespace gestao_campeonato.Service
{
    public class UsuarioService : IUsuarioService
    {
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

    public async Task<IEnumerable<Usuario>> ListAsync()
        {
            return await _usuarioRepository.ListAsync();
        }
        public async Task CadastrarUsuario(Usuario usuario)
        {
            await _usuarioRepository.CadastrarUsuario(usuario);
        }
    }
}