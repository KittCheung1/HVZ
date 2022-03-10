using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class SquadCheckIn
    {
        [Key]
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public Squad Squad { get; set; }
        public int SquadId { get; set; }
        public Squadmember Squadmember { get; set; }
        public int SquadmemberId { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }  
        public double Lat { get; set; }
        public double Lng { get; set; }

    }
}
