using System.ComponentModel.DataAnnotations;
using WebAPI.Models.Domain;

namespace WebAPI.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Game_state { get; set; }

        public double? Nw_lat { get; set; }

        public double? Nw_lng { get; set; }

        public double? Se_lat { get; set; }

        public double? Se_lng { get; set; }

        public ICollection<Player> Players { get; set; }
        public ICollection<Chat> GameChats { get; set; }
        public ICollection<Squad> Squads { get; set; }
    }
}
