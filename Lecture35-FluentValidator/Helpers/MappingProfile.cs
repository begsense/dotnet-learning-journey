using AutoMapper;
using Lecture35_FluentValidator.Models;
using Lecture35_FluentValidator.Requests.Users;
using Lecture35_FluentValidator.Responses.Users;

namespace Lecture35_FluentValidator.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, GetUserResponse>();
        }
    }
}
