using ApiProjeKampi.WebApi.Dtos.CategoryDtos;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Dtos.MessageDtos.MessageDtosForAdminThema.MessageListForNavbarSection;
using ApiProjeKampi.WebApi.Dtos.NotificationDtos;
using ApiProjeKampi.WebApi.Dtos.NotificationDtos.NotificationDtosForAdminThema.NotificationListForNavbarSection;
using ApiProjeKampi.WebApi.Dtos.ProductDtos;
using ApiProjeKampi.WebApi.Dtos.ServiceDtos;
using ApiProjeKampi.WebApi.Dtos.TestimonialDtos;
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
            CreateMap<Message, MessageListByIsReadFalseDto>().ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetByIdNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, NotificationList>().ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, GetByIdServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
            CreateMap<Product, UpdateProductWithCategoryDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
