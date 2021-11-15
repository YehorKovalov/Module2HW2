using System;
using System.Linq;
using Data.Configure;
using Data.Domain.Entities;
using OnlineStore.Controllers;
using Services;

namespace OnlineStore
{
    public class Starter
    {
        private readonly StoreController _storeController = new StoreController();
        private readonly DeviceServices _deviceServices = new DeviceServices();

        public void Run()
        {
            _storeController.Starting();
            var device = new Device();
            for (int i = 0; i < 4; i++)
            {
                device = _deviceServices.GetRandomDevice();
                _storeController.AddingToCart(device);
                _storeController.ChoiceOfContinuing(true);
            }

            _storeController.ChoiceOfContinuing(false);
        }
    }
}
