using System.Collections.Generic;

namespace WebApi.Roman.Domains
{
    public partial class Professores
    {
        public int Id { get; set; }
        public int UsuariosId { get; set; }
        public int EquipeId { get; set; }

        public Equipes Equipe { get; set; }
        public Usuarios Usuarios { get; set; }
        public ICollection<Projetos> Projetos { get; set; }

        public Professores()
        {
            Projetos = new HashSet<Projetos>();
        }
    }
}
