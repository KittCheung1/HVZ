namespace WebAPI.Models.DTO.ChatDTO
{
    public class ReadChatDTO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int? SquadId { get; set; }
        public string Message { get; set; }
        public bool Is_Human_Global { get; set; }
        public bool Is_Zombie_Global { get; set; }
        public string Chat_Time { get; set; }
    }
}
