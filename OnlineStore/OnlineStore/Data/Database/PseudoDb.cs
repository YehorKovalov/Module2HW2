using Data.Configure;
using Data.Database.Seeding;
using Data.Domain.Entities;

namespace Data.Database
{
    public class PseudoDb
    {
        private static readonly PseudoDb _instance = new PseudoDb();

        static PseudoDb()
        {
        }

        private PseudoDb()
        {
        }

        public static PseudoDb Instance
        {
            get
            {
                return _instance;
            }
        }

        private Device[] Devices { get; set; } = new Device[DevicesConfiguration.TempDevicesAmount];

        public Device[] GetDevicesFromDb()
        {
            SeedEntity.SeedDevices(Devices, DevicesConfiguration.TempDevicesAmount);
            return Devices;
        }
    }
}
