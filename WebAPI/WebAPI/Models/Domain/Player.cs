using System.ComponentModel.DataAnnotations;
using WebAPI.Models.Domain;

namespace WebAPI.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public bool Is_Human { get; set; }
        public bool Is_Patient_Zero { get; set; }
        [MaxLength(20)]
        public string Bite_Code { get; set; }
        public ICollection<Kill> Kills { get; set; }
        public ICollection<Kill> Deaths { get; set; }
        public ICollection<Chat> PlayerChats { get; set; }
        public ICollection<Squadmember> Squadmembers { get; set; }
    }
}
