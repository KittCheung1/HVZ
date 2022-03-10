namespace WebAPI.Models.DTO.MissionDTO
{
    public class CreateMissionDTO
    {
        public string Name { get; set; }
        public bool Is_Human_Visible { get; set; }
        public bool Is_Zombie_Visible { get; set; }
        public string? Description { get; set; }
        public string? Start_time { get; set; }
        public string? End_time { get; set; }
    }
}
