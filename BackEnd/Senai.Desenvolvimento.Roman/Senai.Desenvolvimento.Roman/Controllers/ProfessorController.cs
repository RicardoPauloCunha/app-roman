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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private IProfessorRepository ProfessorRepository { get; set; }

        public ProfessorController()
        {
            ProfessorRepository = new ProfessorRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult listarProfessores()
        {
            try
            {

                return Ok(ProfessorRepository.listarProfessores());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("Area/{equipe}")]        
        public IActionResult listarPorArea(string equipe)
        {
            try
            {
                
                return Ok(ProfessorRepository.listarProfessoresPorArea(equipe));                                                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}