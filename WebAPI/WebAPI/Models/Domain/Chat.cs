using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Squad? Squad { get; set; }
        public int? SquadId { get; set; }
        [MaxLength(50)]
        public string Message { get; set; }
        public bool Is_Human_Global { get; set; }
        public bool Is_Zombie_Global { get; set; }
        [MaxLength(20)]
        public string Chat_Time { get; set; }
    }
}
