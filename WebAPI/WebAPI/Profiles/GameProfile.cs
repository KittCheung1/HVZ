using AutoMapper;
using WebAPI.DTO;
using WebAPI.DTO.GameDTO;
using WebAPI.Models;

namespace WebAPI.Profiles

{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<Game, ReadGameDTO>()
                .ReverseMap();
            CreateMap<Game, CreateGameDTO>()
                .ReverseMap();
            CreateMap<Game, EditGameDTO>()
                .ReverseMap();
        }
    }

}
