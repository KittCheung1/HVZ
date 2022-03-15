using WebAPI.Models;

namespace WebAPI.DTO.PlayerDTO
{
    public class ReadPlayerDTO
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public bool Is_Human { get; set; }
        public bool Is_Patient_Zero { get; set; }
        public string Bite_Code { get; set; }
    }
}
