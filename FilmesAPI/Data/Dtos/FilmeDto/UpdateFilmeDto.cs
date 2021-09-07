﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.FilmeDto
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Diretor { get; set; }
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Genero { get; set; }
        [Range(1, 200, ErrorMessage = "Número mínimo de 1 e máximo de 200")]
        public int ClassificacaoEtaria { get; set; }
        public int Duracao { get; set; }
    }
}
