﻿using System.ComponentModel.DataAnnotations;

namespace WholenessAPI.DTOs
{
    public class SucursalDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
