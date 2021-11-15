using System;
using System.Linq;
using System.Text;
using Data.Domain.Entities;
using Data.Models;

namespace Services
{
    public class OrderServices
    {
        private readonly ShoppingCartServices _cartServices;
        private readonly CostServices _costServices;
        public OrderServices()
        {
            _cartServices = new ShoppingCartServices();
            _costServices = new CostServices();
        }

        private Order FormedOrder { get; set; }

        public void FormOrder()
        {
            var addedDevices = _cartServices.GetAddedDevices();

            if (addedDevices.Any())
            {
                FormedOrder = new Order
                {
                    OrderedDevices = addedDevices,
                    TotalPrice = _costServices.CountTotalPrice(addedDevices),
                    DevicesAmount = addedDevices.Length
                };
            }
        }

        public StringBuilder GetOrderedDevices()
        {
            var orderedDevices = new StringBuilder();
            foreach (var device in FormedOrder.OrderedDevices)
            {
                orderedDevices.AppendLine($"{device.Name} - {device.Cost.Price} {device.Cost.Currency}");
            }

            return orderedDevices;
        }

        public string GetOrderedTotalPrice()
        {
            return FormedOrder.TotalPrice.ToString();
        }

        public string GetOrderedDevicesAmount()
        {
            return FormedOrder.DevicesAmount.ToString();
        }
    }
}
