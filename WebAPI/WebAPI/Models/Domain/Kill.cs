using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Kill
    {
        [Key]
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Player Killer { get; set; }
        public int KillerId { get; set; }
        public Player Victim { get; set; }
        public int VictimId { get; set; }
        public string Time_Of_Death { get; set; }
        public string? Story { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }

    }
}
