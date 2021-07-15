using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Roman.Interfaces;
using WebApi.Roman.Repositories;

namespace WebApi.Roman.Controllers
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