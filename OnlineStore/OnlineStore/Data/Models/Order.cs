using Data.Domain.Entities;

namespace Data.Models
{
    public class Order
    {
        public Device[] OrderedDevices { get; init; }
        public decimal TotalPrice { get; set; }
        public int DevicesAmount { get; set; }
    }
}
