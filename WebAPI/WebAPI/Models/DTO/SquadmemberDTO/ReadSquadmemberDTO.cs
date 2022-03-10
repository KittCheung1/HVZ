namespace WebAPI.Models.DTO.SquadmemberDTO
{
    public class ReadSquadmemberDTO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int SquadId { get; set; }
        public int PlayerId { get; set; }
        public string Rank { get; set; }
    }
}
