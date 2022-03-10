namespace WebAPI.Models.DTO.Squad
{
    public class ReadSquadDTO
    {
        public int Id { get; set; }
        public int GameID { get; set; }
        public string Name { get; set; }
        public bool IsHuman { get; set; }
    }
}
