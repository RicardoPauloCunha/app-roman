using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Administradores = new HashSet<Administradores>();
            Professores = new HashSet<Professores>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o email do usuario")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o nome do usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe o Id do tipo de usuário")]
        public int IdTipoUsuario { get; set; }

        public TipoUsuarios IdTipoUsuarioNavigation { get; set; }
        public ICollection<Administradores> Administradores { get; set; }
        public ICollection<Professores> Professores { get; set; }
 
    }
}
