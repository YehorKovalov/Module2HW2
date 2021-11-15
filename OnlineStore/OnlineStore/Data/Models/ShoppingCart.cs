using Data.Configure;
using Data.Domain.Entities;

namespace Data.Models
{
    public class ShoppingCart
    {
        private static readonly ShoppingCart _instance = new ShoppingCart();

        static ShoppingCart()
        {
        }

        private ShoppingCart()
        {
        }

        public static ShoppingCart Instance
        {
            get
            {
                return _instance;
            }
        }

        public Device[] AddedDevices { get; set; } = new Device[100];
    }
}
