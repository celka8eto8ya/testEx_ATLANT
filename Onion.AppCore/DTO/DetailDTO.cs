using System;

namespace Onion.AppCore.DTO
{
    public class DetailDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public string SK_FullName { get; set; }



        public int StorekeeperId { get; set; }
    }
}
