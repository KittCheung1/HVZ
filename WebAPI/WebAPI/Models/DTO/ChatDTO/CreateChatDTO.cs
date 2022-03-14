using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO.ChatDTO
{
    public class CreateChatDTO
    {
        public int PlayerId { get; set; }
        public int? SquadId { get; set; }
        [MaxLength(50)]
        public string Message { get; set; }
        public bool Is_Human_Global { get; set; }
        public bool Is_Zombie_Global { get; set; }
        [MaxLength(20)]
        public string Chat_Time { get; set; }
    }
}
