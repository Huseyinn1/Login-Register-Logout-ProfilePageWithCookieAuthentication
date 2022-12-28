using AutoMapper;
using Webapp3.Entites;
using Webapp3.Models;

namespace Webapp3
{
    public class AutoMapperConfig:Profile

    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, EditUserModel>().ReverseMap();
        }
    }
}
