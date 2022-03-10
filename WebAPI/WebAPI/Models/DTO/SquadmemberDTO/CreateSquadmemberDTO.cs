namespace WebAPI.Models.DTO.SquadmemberDTO
{
    public class CreateSquadmemberDTO
    {
        public int SquadId { get; set; }
        public int PlayerId { get; set; }
        public string Rank { get; set; }
    }
}
