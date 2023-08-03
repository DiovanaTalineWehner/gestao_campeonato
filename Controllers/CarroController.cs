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
    public class CarroController : ControllerBase 
    {
        private readonly ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<IEnumerable<Carro>> GetAllAsync()
        {
            var carros = await _carroService.ListAsync();
            return carros;
        }
        
        [HttpGet("{id}")]
        public async Task<Carro> GetCarro(int id)
        {
            return await _carroService.GetCarro(id);
        }

        [HttpPost]
        [Route("cadastrarcarro")]
        public async Task<ActionResult> CadastrarCarro(Carro carro)
        {
             if(carro == null)
            {
                return BadRequest();
            } 

            var result = await _carroService.CadastrarCarro(carro);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            return Ok(result);
        }    
        /*[HttpGet]
        [Route("[Action]/{id}")]
        public IActionResult Update()
        {
            Conta conta = db.Contas.Find(id);
            if(conta == null) return NotFound();
            conta.Balance += 10; //ADICIONA INFORMAÇÃO
            db.SaveChanges();
            return Ok(conta);
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {   
            var result = await _carroService.DeleteCarro(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            return Ok(result);
        }

    }
}