using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Roman.Domains;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using Senai.Sprint5.Exercicio.Roman.Repositories;
using System;

namespace Senai.Sprint5.Exercicio.Roman.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository ProjetoRepository;

        public ProjetoController()
        {
            ProjetoRepository = new ProjetoRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR, PROFESSOR")]
        [HttpGet]
        public IActionResult ListarProjetos()
        {
            try
            {
                return Ok(ProjetoRepository.ListarProjetos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR, PROFESSOR")]
        [HttpPost]
        public IActionResult Cadastrar(ProjetosViewModel projeto)
        {
            try
            {
                ProjetoRepository.Cadastrar(projeto);
                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
