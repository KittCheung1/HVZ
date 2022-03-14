using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO.Squad
{
    public class EditSquadDTO
    {
        [MaxLength(40)]
        public string Name { get; set; }
        public bool IsHuman { get; set; }
    }
}
