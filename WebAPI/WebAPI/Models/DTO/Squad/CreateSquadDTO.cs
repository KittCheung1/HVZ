namespace WebAPI.Models.DTO.Squad
{
    public class CreateSquadDTO
    {
        public int GameID { get; set; }
        public string Name { get; set; }
        public bool IsHuman { get; set; }
    }
}
