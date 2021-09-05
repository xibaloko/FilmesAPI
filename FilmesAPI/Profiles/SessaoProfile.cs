using AutoMapper;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(sessao => sessao.HoraDeInicio, opts => opts
                .MapFrom(sessao => sessao.HoraDeEncerramento
                .AddMinutes(sessao.Filme.Duracao * (-1))));
        }
    }
}
