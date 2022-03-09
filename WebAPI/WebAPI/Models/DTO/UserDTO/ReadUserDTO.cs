namespace WebAPI.DTO.UserDTO
{
    public class ReadUserDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public bool? Is_Admin { get; set; }
    }
}
