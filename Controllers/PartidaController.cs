/*using System;
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
    public class PartidaController : ControllerBase 
    {
        private readonly IPartidaService _partidaService;

        public PartidaController(IPartidaService partidaService)
        {
            _partidaService = partidaService;
        }
         [HttpGet]
        public async Task<IEnumerable<Partida>> GetAllAsync()
        {
            var partidas = await _partidaService.ListAsync();
            return partidas;
        }
    }
}*/