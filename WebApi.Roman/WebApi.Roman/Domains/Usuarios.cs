using System.Collections.Generic;

namespace WebApi.Roman.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Administradores = new HashSet<Administradores>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }

        public TiposUsuarios TipoUsuario { get; set; }
        public Professores Professores { get; set; }
        public ICollection<Administradores> Administradores { get; set; }
    }
}
