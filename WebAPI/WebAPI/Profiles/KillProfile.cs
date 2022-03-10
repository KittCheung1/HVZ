using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.DTO.KillDTO;

namespace WebAPI.Profiles
{
    public class KillProfile: Profile
    {
        public KillProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<Kill, ReadKillDTO>()
                .ReverseMap();
            CreateMap<Kill, CreateKillDTO>()
                .ReverseMap();
            CreateMap<Kill, EditKillDTO>()
                .ReverseMap();
        }

    }
}
