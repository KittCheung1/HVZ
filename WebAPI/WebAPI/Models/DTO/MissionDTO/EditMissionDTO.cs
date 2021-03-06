using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO.MissionDTO
{
    public class EditMissionDTO
    {
        [MaxLength(40)]
        public string Name { get; set; }
        public bool Is_Human_Visible { get; set; }
        public bool Is_Zombie_Visible { get; set; }
        [MaxLength(80)]
        public string? Description { get; set; }
        public string? Start_time { get; set; }
        public string? End_time { get; set; }
    }
}
