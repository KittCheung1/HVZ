using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string First_Name { get; set; }
        [MaxLength(20)]
        public string Last_Name { get; set; }
        public bool? Is_Admin { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
