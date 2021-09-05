using FilmesAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.SessaoDto
{
    public class ReadSessaoDto
    {
        [Key, Required]
        public int IdSessao { get; set; }
        public Filme Filme { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime HoraDeEncerramento { get; set; }
        public DateTime HoraDeInicio { get; set; }
    }
}
