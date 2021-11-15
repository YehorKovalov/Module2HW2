using System;
using System.Text;
using Data.Domain.Entities;
using Data.Models;

namespace UI
{
    public class ConsoleManager
    {
        public void DisplayStartingWords(Device[] devices)
        {
            Console.WriteLine("Hi, dear customer!");
            DisplayAllDevices(devices);
            Console.WriteLine("Make your purchases.");
        }

        public void NotifyAboutAddingNewDevice()
        {
            Console.Write("Device was added! ");
        }

        public void DisplayDevicesAmount(string amount)
        {
            Console.WriteLine($"Amount: {amount}");
        }

        public void DisplayTotalPrice(string price)
        {
            Console.WriteLine($"Total price: {price}$");
        }

        public void DisplayOrderedDevices(StringBuilder devices)
        {
            Console.WriteLine(devices);
        }

        public void SomethingWentWrongDisplay()
        {
            Console.WriteLine("Something went wrond");
        }

        public bool DisplayChoiceForContinuing(bool justForExample)
        {
            Console.WriteLine("Do you want to continue?");
            Console.WriteLine(justForExample ? "Yes" : "No");
            return justForExample;
        }

        private void DisplayAllDevices(Device[] devices)
        {
            Console.WriteLine("Device name          Price           Is avaliable");
            foreach (var device in devices)
            {
                Console.Write($"{device.Name}       {device.Cost.Price}{device.Cost.Currency}.          ");
                Console.WriteLine(device.IsAvailable ? "Yes" : "No");
            }
        }
    }
}
