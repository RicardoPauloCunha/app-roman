using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Temas
    {
        public Temas()
        {
            Projetos = new HashSet<Projetos>();
        }

        public int Temaid { get; set; }
        [Required(ErrorMessage = "Informe o Tema a ser cadastrado")]
        public string Tema { get; set; }
        [Required(ErrorMessage = "Informe o estado do tema")]
        public bool Ativo { get; set; }

        public ICollection<Projetos> Projetos { get; set; }
    }
}
