using System.ComponentModel.DataAnnotations;
using WebAPI.Models;

namespace WebAPI.DTO.PlayerDTO
{
    public class CreatePlayerDTO
    {
        public string Alias { get; set; }
        public int userId { get; set; }
        public bool is_Human { get; set; }
        public bool is_Patient_Zero { get; set; }
        [MaxLength(20)]
        public string bite_Code { get; set; }
    }
}
