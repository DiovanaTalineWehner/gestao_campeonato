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
        public async Task<ActionResult> CadastrarEquipe(Equipe equipe)
        {
            await _equipeService.CadastrarEquipe(equipe);
            return Ok(new { message = "Equipe created" });
        }    
}}