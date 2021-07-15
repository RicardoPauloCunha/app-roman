using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Roman.Domains;
using WebApi.Roman.Interfaces;
using WebApi.Roman.Repositories;

namespace WebApi.Roman.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {
        private ITemaRepository TemaRepository { get; set; }

        public TemaController()
        {
            TemaRepository = new TemaRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR, PROFESSOR")]
        [HttpGet]
        public IActionResult ListarTemas()
        {
            try
            {
                return Ok(TemaRepository.ListarTemas());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Ativos")]
        [Authorize(Roles = "ADMINISTRADOR, PROFESSOR")]
        [HttpGet]
        public IActionResult ListarTemasAtivos()
        {
            try
            {
                return Ok(TemaRepository.TemasAtivos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR, PROFESSOR")]
        [HttpPost]
        public IActionResult Cadastrar(TemasViewModel tema)
        {
            try
            {
                TemaRepository.Cadastrar(tema);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR, PROFESSOR")]        
        [HttpPut]
        public IActionResult Atualizar(TemasViewModel tema)
        {
            try
            {                
                TemaRepository.Alterar(tema);
                return Ok(tema);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}