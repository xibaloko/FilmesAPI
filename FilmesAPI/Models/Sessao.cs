﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key, Required]
        public int IdSessao { get; set; }
        public virtual Filme Filme { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HoraDeEncerramento { get; set; }
    }
}
