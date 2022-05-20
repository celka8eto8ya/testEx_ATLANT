using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class DetailDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Code, please !")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Code length is [3;100] !")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name length is [1;100] !")]
        public string Name { get; set; }
        [Range(0, 10000000000)]
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public string SK_FullName { get; set; }



        public int StorekeeperId { get; set; }
    }
}
