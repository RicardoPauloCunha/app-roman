using System;
using System.Collections.Generic;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Temas
    {
        public Temas()
        {
            Projetos = new HashSet<Projetos>();
        }

        public int Temaid { get; set; }
        public string Tema { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Projetos> Projetos { get; set; }
    }
}
