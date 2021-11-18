using Data.Domain.Entities;
using Data.Models;
namespace Services
{
    public class CostServices
    {
        public decimal CountTotalPrice(Device[] addedDevices)
        {
            decimal totalPrice = 0;
            foreach (var device in addedDevices)
            {
                totalPrice += CurrencyExchange((decimal)device.Cost.Price, device.Cost.Currency);
            }

            return totalPrice;
        }

        private decimal CurrencyExchange(decimal price, Currency currency)
        {
            decimal exchangedPriceToUSD = 0;

            // Without API, last update 14/11/2021
            switch (currency)
            {
                case Currency.RUB:
                    exchangedPriceToUSD = price * 0.014M;
                    break;
                case Currency.USD:
                    exchangedPriceToUSD = price;
                    break;
                case Currency.EUR:
                    exchangedPriceToUSD = price * 1.14M;
                    break;
                case Currency.UAH:
                    exchangedPriceToUSD = price * 0.038M;
                    break;
            }

            return exchangedPriceToUSD;
        }
    }
}
