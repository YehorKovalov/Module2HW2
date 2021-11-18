using Data.Models;

namespace Data.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Cost Cost { get; set; }
        public bool IsAvailable { get; set; }
    }
}
