using AutoMapper;
using WebAPI.DTO.PlayerDTO;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class PlayerProfile: Profile
    {

        public PlayerProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<Player, ReadPlayerDTO>()
                .ReverseMap();
            CreateMap<Player, CreatePlayerDTO>()
                .ReverseMap();
            CreateMap<Player, EditPlayerDTO>()
                .ReverseMap();
        }

    }
}
