using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Desenvolvimento.Roman.Domains;
using Senai.Desenvolvimento.Roman.Interfaces;
using Senai.Desenvolvimento.Roman.Repositories;

namespace Senai.Desenvolvimento.Roman.Controllers
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
                return Ok(TemaRepository.listarTemas());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{TemasAtivos}")]
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
        public IActionResult Cadastrar(Temas tema)
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
        public IActionResult Atualizar(Temas tema)
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