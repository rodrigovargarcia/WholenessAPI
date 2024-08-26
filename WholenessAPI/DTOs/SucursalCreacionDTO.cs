using System.ComponentModel.DataAnnotations;

namespace WholenessAPI.DTOs
{
    public class SucursalCreacionDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}
