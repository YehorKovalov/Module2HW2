using System;
using System.Linq;
using Data.Domain.Entities;
using Data.Models;

namespace Services
{
    public class ShoppingCartServices
    {
        private readonly ShoppingCart _cart;
        private static int _lastAddedDeviceIndex = 0;
        public ShoppingCartServices()
        {
            _cart = ShoppingCart.Instance;
        }

        public void AddDeviceToCart(Device device)
        {
            if (device != null)
            {
                // I believe that was the last lesson when we was coding without collections
                _cart.AddedDevices[_lastAddedDeviceIndex++] = device;
            }
        }

        public void StopPurchase()
        {
            var temDevices = _cart.AddedDevices;
            Array.Resize(ref temDevices, _lastAddedDeviceIndex);
            _cart.AddedDevices = temDevices;
        }

        public Device[] GetAddedDevices()
        {
            if (_cart.AddedDevices.Any())
            {
                return _cart.AddedDevices;
            }

            Device[] emptyDevicesArray = { };
            return emptyDevicesArray;
        }
    }
}
