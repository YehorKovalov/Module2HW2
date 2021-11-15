using System;
using System.Linq;
using Data.Configure;
using Data.Domain.Entities;
using Data.Models;

namespace Data.Database.Seeding
{
    public static class SeedEntity
    {
        public static void SeedDevices(Device[] seededDevices, int howMany)
        {
            for (int i = 0; i < howMany; i++)
            {
                seededDevices[i] = new Device
                {
                    Id = i,
                    Cost = GetNewCost(),
                    IsAvailable = true,
                    Name = $"Mobilephone:{i}"
                };
            }
        }

        private static Cost GetNewCost()
        {
            var random = new Random();
            int currenciesAmount = Enum.GetNames(typeof(Currency)).Length;
            var newCurrency = (Currency)random.Next(0, currenciesAmount);
            var newCost = new Cost
            {
                Currency = newCurrency,
                Price = random.Next(0, 1000000)
            };
            return newCost;
        }
    }
}
