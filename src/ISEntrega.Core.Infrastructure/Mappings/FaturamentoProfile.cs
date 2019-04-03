namespace ISEntrega.Core.Infrastructure.Mappings
{
    using AutoMapper;
    using ISEntrega.Core.Application.Results;
    using ISEntrega.Core.Application.Commands.Faturamento;
    using ISEntrega.Core.Domain.Faturamento;
    using Entities = Core.EntityFrameworkDataAccess.Entities;

    public class FaturamentoProfile : Profile
    {
        public FaturamentoProfile()
        {
            CreateMap<Faturamento, FaturamentoResult>();
            CreateMap<Faturamento, ProcessaFaturamentoResult>();

            CreateMap<Entities.Matriz, Matriz>().ForMember(
                  dest => dest.Id,
                  opt => opt.MapFrom(src => src.Oid)
            ).ReverseMap();
            CreateMap<Entities.Ponto, Ponto>().ForMember(
                  dest => dest.Id,
                  opt => opt.MapFrom(src => src.Oid)
            ).ReverseMap();
            CreateMap<Entities.Cliente, Cliente>().ForMember(
                  dest => dest.Id,
                  opt => opt.MapFrom(src => src.OID)
            ).ReverseMap();
            CreateMap<Entities.EmpresaFaturamento, EmpresaFaturamento>().ForMember(
                  dest => dest.Id,
                  opt => opt.MapFrom(src => src.Oid)
            ).ReverseMap();
            CreateMap<Entities.InformacaoCobranca, InformacaoCobranca>().ForMember(
                  dest => dest.Id,
                  opt => opt.MapFrom(src => src.Oid)
            ).ReverseMap();
        }
    }
}
