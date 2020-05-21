using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Desenvolvimento.Roman.Domains;
using Senai.Sprint5.Exercicio.Roman.Interfaces;
using Senai.Sprint5.Exercicio.Roman.Repositories;
using Senai.Sprint5.Exercicio.Roman.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.Sprint5.Exercicio.Roman.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository UsuarioRepository;

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult FazerLogin(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);
                if (usuarioBuscado == null)

                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.Tipo.ToString()) 
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-authentication"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                     issuer: "Roman.Manha",
                     audience: "Roman.Manha",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(40),
                     signingCredentials: creds

                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    user = usuarioBuscado
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
