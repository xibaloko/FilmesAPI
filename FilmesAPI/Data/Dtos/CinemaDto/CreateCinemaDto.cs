using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo enderecoId é obrigatório")]
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
