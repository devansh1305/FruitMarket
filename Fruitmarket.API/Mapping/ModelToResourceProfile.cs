using AutoMapper;
using FruitMarket.API.Domain.Models;
using FruitMarket.API.Domain.Models.Queries;
using FruitMarket.API.Extensions;
using FruitMarket.API.Resources;

namespace FruitMarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Bracket, BracketResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            CreateMap<QueryResult<Product>, QueryResultResource<ProductResource>>();
        }
    }
}