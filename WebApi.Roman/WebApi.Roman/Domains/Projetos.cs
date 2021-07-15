namespace WebApi.Roman.Domains
{
    public partial class Projetos
    {
        public int Id { get; set; }
        public string Titutlo { get; set; }
        public string Descricao { get; set; }
        public int TemaId { get; set; }
        public int ProfessorId { get; set; }

        public Professores Professor { get; set; }
        public Temas Tema { get; set; }
    }
}
