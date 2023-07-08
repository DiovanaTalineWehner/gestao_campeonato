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
    public class Local_CampeonatoController : ControllerBase 
    {
        private readonly ILocal_CampeonatoService _local_campeonatoService;

        public Local_CampeonatoController(ILocal_CampeonatoService local_campeonatoService)
        {
            _local_campeonatoService = local_campeonatoService;
        }
         [HttpGet]
        public async Task<IEnumerable<Local_Campeonato>> GetAllAsync()
        {
            var locais_campeonatos = await _local_campeonatoService.ListAsync();
            return locais_campeonatos;
        }
        [HttpPost]
        public async Task<ActionResult> CadastrarLocal(Local_Campeonato local_campeonato)
        {
            await _local_campeonatoService.CadastrarLocal(local_campeonato);
            return Ok(new { message = "Local created" });
        }    
    }
}*/