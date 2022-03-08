namespace WebAPI.Models
{
    public class Game
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Game_state { get; set; }

        public double? Nw_lat { get; set; }

        public double? Nw_lng { get; set; }

        public double? Se_lat { get; set; }

        public double? Se_lng { get; set; }


    }
}
