namespace WebAPI.Models.DTO.SquadCheckInDTO
{
    public class CreateSquadCheckInDTO
    {
        public int SquadId { get; set; }
        public int SquadmemberId { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
