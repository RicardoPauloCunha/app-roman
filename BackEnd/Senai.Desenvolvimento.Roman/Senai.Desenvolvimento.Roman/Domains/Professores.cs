using System;
using System.Collections.Generic;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Professores
    {
        public Professores()
        {
            Projetos = new HashSet<Projetos>();
        }

        public int ProfessorId { get; set; }
        public int IdUsuario { get; set; }
        public int IdArea { get; set; }

        public Equipes IdAreaNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Projetos> Projetos { get; set; }
    }
}
