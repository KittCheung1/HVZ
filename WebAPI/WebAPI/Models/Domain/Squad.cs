using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class Squad
    {
        [Key]
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameID { get; set; }
        public string Name { get; set; }
        public bool IsHuman { get; set; }
        public ICollection<Chat> SquadChats { get; set; }
    }
}
