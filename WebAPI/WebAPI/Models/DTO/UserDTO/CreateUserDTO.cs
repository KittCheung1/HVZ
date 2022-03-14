using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.UserDTO
{
    public class CreateUserDTO
    {
        [MaxLength(20)]
        public string First_Name { get; set; }
        [MaxLength(20)]
        public string Last_Name { get; set;}
    }
}
