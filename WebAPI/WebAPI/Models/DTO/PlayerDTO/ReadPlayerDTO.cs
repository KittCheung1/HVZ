using WebAPI.Models;

namespace WebAPI.DTO.PlayerDTO
{
    public class ReadPlayerDTO
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int gameId { get; set; }
        public bool is_Human { get; set; }
        public bool is_Patient_Zero { get; set; }
        public string bite_Code { get; set; }
    }
}
