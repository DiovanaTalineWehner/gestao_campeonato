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
    [Authorize]

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
        [HttpPost]
        [Route("cadastrarclassificacao")]

        public async Task<ActionResult> CadastrarClassificacao(Classificacao classificacao)
        {
            if(classificacao == null)
            {
                return BadRequest();
            }
            var result = await _classificacaoService.CadastrarClassificacao(classificacao);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            return Ok(result);
        }

    }
}