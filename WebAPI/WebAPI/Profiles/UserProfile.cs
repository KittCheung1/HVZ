using AutoMapper;
using WebAPI.DTO.UserDTO;
using WebAPI.Models;

namespace WebAPI.Profiles

{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<User, ReadUserDTO>()
                .ReverseMap();
            CreateMap<User, CreateUserDTO>()
                .ReverseMap();
            CreateMap<User, EditUserDTO>()
                .ReverseMap();
        }
    }

}
