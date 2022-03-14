using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.GameDTO
{
    public class CreateGameDTO
    {
        [MaxLength(40)]
        public string Name { get; set; }

        public int Game_state { get; set; }

        public double? Nw_lat { get; set; }

        public double? Nw_lng { get; set; }

        public double? Se_lat { get; set; }

        public double? Se_lng { get; set; }

    }
}
