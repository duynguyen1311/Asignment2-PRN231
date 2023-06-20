using AutoMapper;
using BusinessObject.Model;
using eBookStoreWebAPI.DTO;

namespace eBookStoreWebAPI.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<BookDTO, Book>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<AuthorDTO, Author>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<BookAuthorDTO, BookAuthor>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<PublisherBookDTO, Publisher>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
            CreateMap<BusinessObject.RequestDTO.UserRequestDTO.LoginResponseModel, User>().ReverseMap().ForAllMembers(x => x.Condition((source, target, sourceValue) => sourceValue != null));
        }
    }
}
