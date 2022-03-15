using System.ComponentModel.DataAnnotations;
using WebAPI.Models;

namespace WebAPI.DTO.PlayerDTO
{
    public class CreatePlayerDTO
    {
        public string Alias { get; set; }
        public int UserId { get; set; }
        public bool Is_Human { get; set; }
        public bool Is_Patient_Zero { get; set; }
        [MaxLength(20)]
        public string Bite_Code { get; set; }
    }
}
