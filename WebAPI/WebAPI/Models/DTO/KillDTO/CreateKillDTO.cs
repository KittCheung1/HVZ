using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO.KillDTO
{
    public class CreateKillDTO
    {
        public int KillerId { get; set; }
        public int VictimId { get; set; }
        public string Time_Of_Death { get; set; }
        [MaxLength(80)]
        public string? Story { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}
