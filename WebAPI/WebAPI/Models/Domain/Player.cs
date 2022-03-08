using System.ComponentModel.DataAnnotations;

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
        public int Is_Human { get; set; }
        public int Is_Patient_Zero { get; set; }
        public string Bite_Code { get; set; }
        public ICollection<Kill> Kills { get; set; }
        public ICollection<Kill> Deaths { get; set; }
    }
}
