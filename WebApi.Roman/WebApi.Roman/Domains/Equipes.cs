using System.Collections.Generic;

namespace WebApi.Roman.Domains
{
    public partial class Equipes
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Professores> Professores { get; set; }

        public Equipes()
        {
            Professores = new HashSet<Professores>();
        }
    }
}
