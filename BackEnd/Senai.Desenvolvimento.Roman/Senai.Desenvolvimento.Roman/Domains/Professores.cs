using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Professores
    {

        public int ProfessorId { get; set; }
        [Required(ErrorMessage = "Informe o Id do Usuário")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Informe o Id da Equipe")]
        public int IdEquipe { get; set; }

        public Equipes IdEquipeNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
