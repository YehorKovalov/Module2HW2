using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain.Entities;
using Services;
using UI;

namespace OnlineStore.Controllers
{
    public class StoreController
    {
        private readonly DeviceServices _deviceServices;
        private readonly OrderServices _orderServices;
        private readonly ShoppingCartServices _cartServices;
        private readonly ConsoleManager _console;

        public StoreController()
        {
            _cartServices = new ShoppingCartServices();
            _deviceServices = new DeviceServices();
            _orderServices = new OrderServices();
            _console = new ConsoleManager();
        }

        public void Starting()
        {
            var devices = _deviceServices.GetDevices();
            if (devices.Any())
            {
                _console.DisplayStartingWords(devices);
                return;
            }

            _console.SomethingWentWrongDisplay();
        }

        public void AddingToCart(Device device)
        {
            if (device != null)
            {
                _cartServices.AddDeviceToCart(device);
                _console.NotifyAboutAddingNewDevice();
                return;
            }

            _console.SomethingWentWrongDisplay();
        }

        public void ChoiceOfContinuing(bool forExample)
        {
            bool isContinued = _console.DisplayChoiceForContinuing(forExample);
            if (!isContinued)
            {
                _cartServices.StopPurchase();
                MakeOrder();
            }
        }

        public void MakeOrder()
        {
            _orderServices.FormOrder();
            var devices = _orderServices.GetOrderedDevices();
            var amount = _orderServices.GetOrderedDevicesAmount();
            var totalPrice = _orderServices.GetOrderedTotalPrice();
            _console.DisplayDevicesAmount(amount);
            _console.DisplayOrderedDevices(devices);
            _console.DisplayTotalPrice(totalPrice);
        }
    }
}
