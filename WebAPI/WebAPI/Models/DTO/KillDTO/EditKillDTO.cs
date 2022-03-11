namespace WebAPI.Models.DTO.KillDTO
{
    public class EditKillDTO
    {
        public int KillerId { get; set; }
        public int VictimId { get; set; }
        public string Time_Of_Death { get; set; }
        public string? Story { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}
