using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.Domain
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public bool Is_Human_Visible { get; set; }
        public bool Is_Zombie_Visible { get; set; }
        [MaxLength(80)]
        public string? Description { get; set; }
        public string? Start_time { get; set; }
        public string? End_time { get; set;}
    }
}
