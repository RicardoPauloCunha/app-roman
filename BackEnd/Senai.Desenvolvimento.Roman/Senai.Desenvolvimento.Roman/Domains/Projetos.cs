using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Projetos
    {
        public int ProjetoId { get; set; }
        [Required(ErrorMessage = "Informe o titulo do projeto")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Informe a descrição do projeto")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe o Id do Tema")]
        public int IdTema { get; set; }
        [Required(ErrorMessage = "Informe o Id do Professor")]
        public int IdProfessor { get; set; }

        public Temas IdTemaNavigation { get; set; }
        public Usuarios Usuario { get; set; }
        public Professores Professor { get; set; }

    }
}
