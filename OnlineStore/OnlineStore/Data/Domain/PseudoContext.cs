using Data.Domain.Entities;
using Data.Database;

namespace Data.Domain
{
    public class PseudoContext
    {
        public Device[] Devices { get; set; } = PseudoDb.Instance.GetDevicesFromDb();
    }
}
