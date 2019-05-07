using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Desenvolvimento.Roman.Domains;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using Senai.Sprint5.Exercicio.Roman.Repositories;

namespace Senai.Desenvolvimento.Roman.Controllers
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

        //[Authorize(Roles = "ADMINISTRADOR")]
        //[HttpPost]
        //public IActionResult Cadastrar(Usuarios usuario)
        //{
        //    try
        //    {
        //        UsuarioRepository.Cadastrar(usuario);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}