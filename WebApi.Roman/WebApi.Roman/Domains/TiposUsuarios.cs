using System.Collections.Generic;

namespace WebApi.Roman.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
