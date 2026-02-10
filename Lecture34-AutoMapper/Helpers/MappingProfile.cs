using AutoMapper;
using Lecture34_AutoMapper.Requests;
using Lecture34_AutoMapper.Models;
using Lecture34_AutoMapper.Responses;
namespace Lecture34_AutoMapper.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<Product, GetProduct>();
    }
}
