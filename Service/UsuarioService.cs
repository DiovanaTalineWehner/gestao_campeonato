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

        public async Task<Usuario> GetUsuarioByEmail(string email_usuario)
        {
            return await _usuarioRepository.GetUsuarioByEmail(email_usuario);
        }

        public bool CheckPasswordAsync(Usuario user, string password)
        {
            if (user == null || password == "")
            {
                return false;
            }
            if (user.senha_usuario == password)
            {
                return true;
            }
            return false;
        }

      /*  public async Task CadastrarUsuario(Usuario usuario)
        {
            await _usuarioRepository.CadastrarUsuario(usuario);
        }*/
         public async Task<UsuarioResponse> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                var existingUsuario = await _usuarioRepository.GetUsuarioByEmail(usuario.email_usuario);
                if (existingUsuario != null)
                {
                    return new UsuarioResponse("Já existe um usuário com esse email.");
                }
                await _usuarioRepository.CadastrarUsuario(usuario);

                return new UsuarioResponse(usuario);
            }
            catch (Exception ex)
            {
                return new UsuarioResponse($"An error occurred when saving the product: {ex.Message}");
            }
    }
}
}