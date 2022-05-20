using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class StorekeeperDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Full Name, please !")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full Name length is [3;100] !")]
        public string FullName { get; set; }
        public int DetailAmount { get; set; }
        
    }
}
