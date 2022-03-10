using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.SquadCheckInDTO;

namespace WebAPI.Profiles
{
    public class SquadCheckInProfile: Profile
    {
        public SquadCheckInProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<SquadCheckIn, ReadSquadCheckInDTO>()
                .ReverseMap();
            CreateMap<SquadCheckIn, CreateSquadCheckInDTO>()
                .ReverseMap();
            CreateMap<SquadCheckIn, EditSquadCheckInDTO>()
                .ReverseMap();
        }
    }
}
