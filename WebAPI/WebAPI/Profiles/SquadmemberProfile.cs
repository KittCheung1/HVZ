using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.Squad;
using WebAPI.Models.DTO.SquadmemberDTO;

namespace WebAPI.Profiles
{
    public class SquadmemberProfile: Profile
    {
        public SquadmemberProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<Squadmember, ReadSquadmemberDTO>()
                .ReverseMap();
            CreateMap<Squadmember, CreateSquadmemberDTO>()
                .ReverseMap();
            CreateMap<Squadmember, EditSquadmemberDTO>()
                .ReverseMap();
        }
    }
}
