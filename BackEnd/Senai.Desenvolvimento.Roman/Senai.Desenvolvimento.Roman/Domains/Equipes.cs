using System;
using System.Collections.Generic;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Equipes
    {
        public int EquipeId { get; set; }
        public string Nome { get; set; }

        public Professores professor { get; set; }
    }
}
