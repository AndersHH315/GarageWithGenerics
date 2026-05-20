using System;
using GarageGenerics.Handler;
using GarageGenerics.VehicleType;

namespace GarageGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageHandler garageHandler = new();
            Menu showMenu = new();
            string? input = "";
            Console.WriteLine("Create a garage by enter the amount of spots in numbers!");
            string? spots = Console.ReadLine();
            while (!int.TryParse(spots, out int check))
            {
                Console.WriteLine("Type a number between 1-100!");
                spots = Console.ReadLine();
            }
            Garage<Vehicle> garage = new(int.Parse(spots));
            garage.ParkVehicles();;
            do
            {
                showMenu.MainMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                    Console.WriteLine("Closing down the garage!");
                    break;
                    case "1":
                    garage.ParkNewVehicle();
                    break;
                    case "2":
                    garage.ShowParkedVehicles();
                    break;
                    case "3":
                    garage.ShowTypeOfParkedVehicles();
                    break;
                    case "4":
                    garage.SearchParkedVehicles();
                    break;
                    case "5":
                    garage.UnParkVehicle();
                    break;
                    default:
                    Console.WriteLine("Invalid entry! Try again!");
                    break;
                }                    
            } while (input != "0");
        }
    }
}