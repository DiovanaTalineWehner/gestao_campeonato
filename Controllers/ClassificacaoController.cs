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
    public class ClassificacaoController : ControllerBase 
    {
        private readonly IClassificacaoService _classificacaoService;

        public ClassificacaoController(IClassificacaoService classificacaoService)
        {
            _classificacaoService = classificacaoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Classificacao>> GetAllAsync()
        {
            var Classificacoes = await _classificacaoService.ListAsync();
            return Classificacoes;
        }

    }
}