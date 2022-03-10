using AutoMapper;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO.ChatDTO;

namespace WebAPI.Profiles
{
    public class ChatProfile: Profile
    {
        public ChatProfile()
        {
            //Creates maps between two different classes to only show relevant and objective data about each model, one for each DTO
            CreateMap<Chat, ReadChatDTO>()
                .ReverseMap();
            CreateMap<Chat, CreateChatDTO>()
                .ReverseMap();
            CreateMap<Chat, EditChatDTO>()
                .ReverseMap();
        }
    }
}
