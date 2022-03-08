using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.Squad;

namespace WebAPI.Profiles
{
    public class SquadmemberProfile: Profile
    {
        public SquadmemberProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<Squad, ReadSquadDTO>()
                .ReverseMap();
            CreateMap<Squad, CreateSquadDTO>()
                .ReverseMap();
            CreateMap<Squad, EditSquadDTO>()
                .ReverseMap();
        }
    }
}
