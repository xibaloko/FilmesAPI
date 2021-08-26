using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmesContext _context;

        public FilmeController(FilmesContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = new Filme()
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao
            };

            _context.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFilme), new {id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult GetFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = new ReadFilmeDto()
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    DataConsulta = DateTime.Now
                };

                return Ok(filmeDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] ReadFilmeDto filmeAtualizado)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            filme.Diretor = filmeAtualizado.Diretor;
            filme.Duracao = filmeAtualizado.Duracao;
            filme.Genero = filmeAtualizado.Genero;
            filme.Titulo = filmeAtualizado.Titulo;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (filme == null)
            {
                return NotFound();
            }

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
