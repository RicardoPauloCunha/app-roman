using System;
using System.Collections.Generic;

namespace Senai.Desenvolvimento.Roman.Domains
{
    public partial class TipoUsuarios
    {
        public TipoUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int TipoUsuarioId { get; set; }
        public string Tipo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
