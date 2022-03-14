using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class Squad
    {
        [Key]
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameID { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public bool IsHuman { get; set; }
        public ICollection<Chat> SquadChats { get; set; }
        public ICollection<Squadmember> Squadmembers { get; set; }
        public ICollection<SquadCheckIn> SquadCheckIns { get; set; }
    }
}
