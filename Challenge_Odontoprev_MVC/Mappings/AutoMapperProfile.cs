using AutoMapper;
using Challenge_Odontoprev_MVC.Models.Entities;
using Challenge_Odontoprev_MVC.Application.DTOs;

namespace Challenge_Odontoprev_MVC.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() {
        CreateMap<Paciente, PacienteReadDTO>();
        CreateMap<PacienteCreateDTO, Paciente>();

        CreateMap<Dentista, DentistaReadDTO>();
        CreateMap<DentistaCreateDTO, Dentista>();

        CreateMap<Consulta, ConsultaReadDTO>();
        CreateMap<ConsultaCreateDTO, Consulta>();

        CreateMap<HistoricoConsulta, HistoricoConsultaReadDTO>();
        CreateMap<HistoricoConsultaCreateDTO, HistoricoConsulta>();
    }
}
