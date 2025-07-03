using AutoMapper;
using Bakery.Infrastructure.Models;
using Bakery.Services.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductCreateDto, Product>();
    }
}

    