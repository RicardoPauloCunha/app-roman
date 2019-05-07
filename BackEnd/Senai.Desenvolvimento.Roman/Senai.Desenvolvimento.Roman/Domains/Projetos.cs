using System;
using System.Collections.Generic;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class Projetos
    {
        public int ProjetoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdTema { get; set; }
        public int IdProfessor { get; set; }

        public Temas IdTemaNavigation { get; set; }
        public Usuarios Usuario { get; set; }
        public Professores Professor { get; set; }

    }
}
