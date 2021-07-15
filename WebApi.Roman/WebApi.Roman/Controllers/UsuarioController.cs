using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using Senai.Sprint5.Exercicio.Roman.Repositories;

namespace WebApi.Roman.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       private IUsuarioRepository UsuarioRepository { get; set; }
       
        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            try
            {
                return Ok(UsuarioRepository.ListarUsuarios());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}