using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class Squadmember
    {
        [Key]
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Squad Squad { get; set; }
        public int SquadId { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public string Rank { get; set; }
    }
}
