using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gestao_campeonato.Database;
using gestao_campeonato.Service;
using gestao_campeonato.Models;

namespace gestao_campeonato.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsuarioController : ControllerBase 
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
         [HttpGet]
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = await _usuarioService.ListAsync();
            return usuarios;
        }
         [HttpPost]
        public async Task<ActionResult> CadastrarUsuario(Usuario usuario)
        {
            await _usuarioService.CadastrarUsuario(usuario);
            return Ok(new { message = "Usuario created" });
        }    
    }
}