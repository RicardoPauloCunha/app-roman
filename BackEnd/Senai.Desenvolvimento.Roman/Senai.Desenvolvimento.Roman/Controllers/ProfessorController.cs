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
        private readonly IProfessorRepository ProfessorRepository;

        public ProfessorController()
        {
            ProfessorRepository = new ProfessorRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult ListarProfessores()
        {
            try
            {
                return Ok(ProfessorRepository.ListarProfessores());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("Area/{equipe}")]        
        public IActionResult ListarPorArea(string equipe)
        {
            try
            {
                return Ok(ProfessorRepository.ListarProfessoresPorArea(equipe));                                                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}