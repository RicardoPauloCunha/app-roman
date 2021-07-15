using System.ComponentModel.DataAnnotations;

namespace WebApi.Roman.Domains
{
    public class TemasViewModel
    {
        public int TemaId { get; set; }

        [Required(ErrorMessage = "Coloque o Tema a ser cadastrado")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "Coloque o estado do tema")]
        public bool Ativo { get; set; }
    }
}
