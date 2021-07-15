namespace WebApi.Roman.Domains
{
    public partial class Administradores
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public Usuarios Usuario { get; set; }
    }
}
