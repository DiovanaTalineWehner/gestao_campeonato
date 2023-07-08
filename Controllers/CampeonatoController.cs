using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gestao_campeonato.Database;
using gestao_campeonato.Service;
using gestao_campeonato.Models;
using Microsoft.AspNetCore.Authorization;
using gestao_campeonato.Service.Communication;

namespace gestao_campeonato.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CampeonatoController : ControllerBase 
    {
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }
         [HttpGet]
        public async Task<IEnumerable<Campeonato>> GetAllAsync()
        {
            var Campeonatos = await _campeonatoService.ListAsync();
            return Campeonatos;
        }
        [HttpPost]
        [Route("cadastrarcampeonato")]
        public async Task<ActionResult> CadastrarCampeonato(Campeonato campeonato)
        {
            if(campeonato == null)
            {
                return BadRequest();
            }
            var result = await _campeonatoService.CadastrarCampeonato(campeonato);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            await _campeonatoService.CadastrarCampeonato(campeonato);
            return Ok(result);
        }    
    }
}