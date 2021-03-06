using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key, Required]
        public int Id { get; set; }

        [Required (ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Diretor { get; set; }
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Genero { get; set; }
        [Range(1, 200, ErrorMessage = "Número mínimo de 1 e máximo de 200")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
