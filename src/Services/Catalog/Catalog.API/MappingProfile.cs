using AutoMapper;
using Catalog.API.Dtos;
using Catalog.Domain.Entities;

namespace Catalog.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}