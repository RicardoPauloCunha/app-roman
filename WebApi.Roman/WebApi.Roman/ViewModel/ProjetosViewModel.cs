using System.ComponentModel.DataAnnotations;

namespace WebApi.Roman.Domains
{
    public class ProjetosViewModel
    {
        [Required(ErrorMessage = "Coloque o titulo do projeto")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Coloque a descrição do projeto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Coloque o Id do tema do projeto")]
        public int TemasId { get; set; }

        [Required(ErrorMessage = "Coloque o Id do professor do projeto")]
        public int ProfessorId { get; set; }
    }
}
