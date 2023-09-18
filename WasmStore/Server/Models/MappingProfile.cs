using AutoMapper;
using WasmStore.Shared;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<ProductDTO, Product>();
    }
}