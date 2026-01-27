using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Dtos.ProductDtos;
using ApiProjeKampi.WebApi.Dtos.ServiceDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;

namespace ApiProjeKampi.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, GetByIdServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
        }
    }
}
