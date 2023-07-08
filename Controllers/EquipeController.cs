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
    public class EquipeController : ControllerBase 
    {
        private readonly IEquipeService _equipeService;

        public EquipeController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }
        [HttpGet]
        public async Task<IEnumerable<Equipe>> GetAllAsync()
        {
            var equipes = await _equipeService.ListAsync();
            return equipes;
        }

        [HttpPost]
        [Route("cadastrarequipe")]
        public async Task<ActionResult> CadastrarEquipe(Equipe equipe)
        {
            if(equipe == null)
            {
                return BadRequest();
            }

            var result = await _equipeService.CadastrarEquipe(equipe);

            if(!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            return Ok(result);
        }    
}}