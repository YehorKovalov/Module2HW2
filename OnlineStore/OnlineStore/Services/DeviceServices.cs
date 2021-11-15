using System;
using System.Linq;
using Data.Configure;
using Data.Domain;
using Data.Domain.Entities;

namespace Services
{
    public class DeviceServices
    {
        private readonly PseudoContext _db;

        public DeviceServices()
        {
            _db = new PseudoContext();
        }

        public Device[] GetDevices()
        {
            if (_db.Devices.Any())
            {
                return _db.Devices;
            }

            Device[] emptyDevicesArray = { };
            return emptyDevicesArray;
        }

        public Device GetRandomDevice()
        {
            var devices = GetDevices();
            var rand = new Random();
            var randomedId = 0;
            randomedId = rand.Next(0, DevicesConfiguration.TempDevicesAmount + 1);

            // Please, don't be mad on linq...I am exhausted
            return devices.FirstOrDefault(device => device.Id == randomedId);
        }
    }
}
