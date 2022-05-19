using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.Entities
{
    public class Storekeeper
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
