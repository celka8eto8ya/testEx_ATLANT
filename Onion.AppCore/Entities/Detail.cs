using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        
        [Required]
        public string Code { get; set; }
        
        [Required]
        public string Name { get; set; }
        public int Amount { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }


        public Storekeeper Storekeeper { get; set; }
        [Required]
        public int StorekeeperId { get; set; }
    }
}
