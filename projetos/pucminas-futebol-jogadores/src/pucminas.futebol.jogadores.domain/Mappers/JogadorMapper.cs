using AutoMapper;
using pucminas.futebol.jogadores.domain.DTOs;
using pucminas.futebol.jogadores.domain.Entidades;

namespace pucminas.futebol.jogadores.domain.Mappers
{
    public class JogadorMapper : Profile
    {
        public JogadorMapper()
        {
            CreateMap<Jogador, JogadorResponseDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id.ToString())
                )
                .ForMember(
                    dest => dest.DataCadastro,
                    opt => opt.MapFrom(src => src.Criacao.ToString("dd-MM-yyyy"))
                )
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => src.Nome)
                )
                .ForMember(
                    dest => dest.Sobrenome,
                    opt => opt.MapFrom(src => src.Sobrenome)
                )
                .ForMember(
                    dest => dest.DataNascimento,
                    opt => opt.MapFrom(src => src.DataNascimento.ToString("dd-MM-yyyy"))
                )
                .ForMember(
                    dest => dest.Pais,
                    opt => opt.MapFrom(src => src.Pais)
                )
                .ForMember(
                    dest => dest.IdTime,
                    opt => opt.MapFrom(src => src.IdTime)
                );
        }
    }
}
