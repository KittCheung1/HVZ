using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.MissionDTO;

namespace WebAPI.Profiles
{
    public class MissionProfile: Profile
    {

        public MissionProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<Mission, ReadMissionDTO>()
                .ReverseMap();
            CreateMap<Mission, CreateMissionDTO>()
                .ReverseMap();
            CreateMap<Mission, EditMissionDTO>()
                .ReverseMap();
        }
    }
}
