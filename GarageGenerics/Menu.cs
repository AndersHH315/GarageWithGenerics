using System;

namespace GarageGenerics
{
    internal class Menu
    {
        public void MainMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("-------Welcome To The Garage-------");
            Console.WriteLine("1. Store a vehicle in the garage.");
            Console.WriteLine("2. List current vehicles in the garage.");
            Console.WriteLine("3. List all types of vehicles in the garage.");
            Console.WriteLine("4. Search for a vehicle or vehicles.");
            Console.WriteLine("5. Remove a vehicle.");
            Console.WriteLine("0. Empty and close down the garage.");
            Console.WriteLine("------------------------------------");
            Console.WriteLine(" ");
        }

        public void VehicleMenu()
        {
            Console.WriteLine("What type of vehicle?\n1. Car\n2. Motorcycle\n3. Boat\n4. Bus\n5. Airplane");
        }

        public void SearchMenu()
        {
            Console.WriteLine("Select your search method\n1. By registernumber\n2. By colour\n3. include more then 1 property");
            // Console.WriteLine("1. By registernumber");
            // Console.WriteLine("2. By colour");
            // Console.WriteLine("3. include more then 1 property");
        }

        public void ColourMenu()
        {
            Console.WriteLine("What colour is your vehicle?");
        }

        public void FuelMenu()
        {
            Console.WriteLine("What type of fuel does your vehicle consume?\n1. Gasoline\n2. Diesel\n3. Electricity");
            // Console.WriteLine("1. Gasoline");
            // Console.WriteLine("2. Diesel");
            // Console.WriteLine("3. Electricity");
        }
    }
}