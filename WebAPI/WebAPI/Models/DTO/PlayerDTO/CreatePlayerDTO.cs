﻿using WebAPI.Models;

namespace WebAPI.DTO.PlayerDTO
{
    public class CreatePlayerDTO
    {
        public int userId { get; set; }
        public int is_Human { get; set; }
        public int is_Patient_Zero { get; set; }
        public string bite_Code { get; set; }
    }
}