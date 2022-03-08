namespace WebAPI.Models.Domain
{
    public class Chat
    {
        public int Id { get; set; }

        public Game Game { get; set; }
        public int GameId { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        //public Squad Squad { get; set; }
        //pubic int SquadId { get; set; }
        public string Message { get; set; }
        public bool Is_Human_Global { get; set; }
        public bool Is_Zombie_Global { get; set; }
        public string Chat_Time { get; set; }
    }
}
