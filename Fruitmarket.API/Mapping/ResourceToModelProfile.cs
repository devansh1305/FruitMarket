using AutoMapper;
using FruitMarket.API.Domain.Models;
using FruitMarket.API.Domain.Models.Queries;
using FruitMarket.API.Resources;

namespace FruitMarket.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveBracketResource, Bracket>();

            CreateMap<SaveProductResource, Product>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => (EUnitOfMeasurement)src.UnitOfMeasurement));

            CreateMap<ProductsQueryResource, ProductsQuery>();
        }
    }
}