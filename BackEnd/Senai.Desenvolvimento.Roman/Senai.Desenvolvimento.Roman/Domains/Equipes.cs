using System;
using System.Collections.Generic;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Equipes
    {
        public Equipes()
        {
            Professores = new HashSet<Professores>();
        }

        public int EquipeId { get; set; }
        public string Equipe { get; set; }

        public ICollection<Professores> Professores { get; set; }
    }
}
