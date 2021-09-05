using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSessao), new { id = sessao.IdSessao }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(x => x.IdSessao == id);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
                return Ok(sessaoDto);
            }

            return NotFound();
        }
    }
}
