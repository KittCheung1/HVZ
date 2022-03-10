using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public bool? Is_Admin { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
