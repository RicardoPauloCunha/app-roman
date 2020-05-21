using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public class ProjetosViewModel
    {
        [Required(ErrorMessage = "Coloque o titulo do projeto")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Coloque a descrição do projeto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Coloque o Id do tema do projeto")]
        public int IdTema { get; set; }

        [Required(ErrorMessage = "Coloque o Id do professor do projeto")]
        public int IdProfessor { get; set; }
    }
}
