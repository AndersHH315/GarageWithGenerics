using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using GarageGenerics;
using GarageGenerics.Interface;
using GarageGenerics.VehicleType;
using GarageGenerics.VehicleType.VehicleParts;

namespace GarageGenerics.Handler
{
    public class GarageHandler : IGarageHandler
    {
        private List<Vehicle> Vehicles = new List<Vehicle>();
        Menu menu = new();
        private int _parkingSpots = 0;
        public List<Vehicle> AddSomeVehicle()
        {
            Vehicles.Add(new Car("ABC123", "Red", 4, FuelType.Diesel));
            Vehicles.Add(new Motorcycle("DEF456", "Blue", 2, 4));
            Vehicles.Add(new Boat("GHI789", "Green", 0, 5));
            Vehicles.Add(new Bus("JKL012", "Yellow", 4, 24));
            Vehicles.Add(new Airplane("MNO345", "Orange", 6, 3));
            Console.WriteLine("5 vehicles added to the garage!");
            ShowVehicles(Vehicles);
            return Vehicles;
               
        }
        public string AddNewVehicle(Vehicle[] vehicles)
        {
            _parkingSpots = vehicles.Length;
            menu.VehicleMenu();
            string? input = Console.ReadLine();
            string? output = "No vehicle has been parked!";
            while (!int.TryParse(input, out int result) && result < 1 || result > 5)
            {
                Console.WriteLine("Wrong input! Type a number between 1-5!");
                input = Console.ReadLine();
            }           
            int choice = int.Parse(input);
            for (int i = 0; i < vehicles.Length; i++)
            {
                if(vehicles[i] == null)
                {
                    vehicles[i] = ChooseVehicle(choice);
                    Vehicles.Add(vehicles[i]);
                    output = "Vehicle added to spot " + i;
                    return output;
                                        
                }
                else if(!vehicles.Contains(null))
                {
                    Console.WriteLine("No empty spots left!");
                    Console.WriteLine("Do you want to expand the garage? (y/n)");
                    input = Console.ReadLine();
                    while (input != "y" && input != "n")
                    {
                        Console.WriteLine("Invalid input! Enter 'y' or 'n'");
                        input = Console.ReadLine();
                    }
                    if(input == "n")
                    {
                        Console.WriteLine("Okay, will not expand the garage any further for now!");
                    }
                    else if(input == "y")
                    {
                        Console.WriteLine("Expanding the garage");
                        _parkingSpots++;
                        Vehicle[] newVehicles = new Vehicle[_parkingSpots];
                        Array.Copy(vehicles, newVehicles, Vehicles.Count);
                        vehicles = newVehicles;
                        vehicles[_parkingSpots - 1] = ChooseVehicle(choice);
                        Vehicles.Add(vehicles[i]);
                        output = "Vehicle added to spot " + (_parkingSpots - 1);
                        return output;
                    }
                }
            }
            return output;
        }
        public Car AddNewCar()
        {
            string regNmbr = RegisterNumber();
            string colour = ColourType();
            menu.FuelMenu();
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out int result) && result < 1 || result > 3)
            {
                Console.WriteLine("Choose a fuel type between 1-3");
                input = Console.ReadLine();
            }
            int fuel = int.Parse(input);
            Car car = new(regNmbr, colour, 4,  WhatFuel(fuel));
            return car;
        }
        public Bus AddNewBus()
        {
            string regNmbr = RegisterNumber();
            string colour = ColourType();
            Console.WriteLine("How many seats does the bus ahve");
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enter the amount of seats in numbers!");
                input = Console.ReadLine();
            }
            int seats = int.Parse(input);
            Bus bus = new(regNmbr, colour, 4, seats);
            return bus;
        }
        public Boat AddNewBoat()
        {
            string regNmbr = RegisterNumber();
            string colour = ColourType();
            Console.WriteLine("Whats the length of your boat?");
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enter the length in numbers!");
                input = Console.ReadLine();
            }
            int length = int.Parse(input);
            Boat boat = new(regNmbr, colour, 0, length);
            return boat;
        }
        public Motorcycle AddNewMotorcyle()
        {
            string regNmbr = RegisterNumber();
            string colour = ColourType();
            Console.WriteLine("How many cylinders?");
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enter the amount of cylinders in numbers!");
                input = Console.ReadLine();
            }
            int cylinder = int.Parse(input);
            Motorcycle motorcycle = new(regNmbr, colour, 2, cylinder);
            return motorcycle;
        }
        public Airplane AddNewAirPlane()
        {
            string regNmbr = RegisterNumber();
            string colour = ColourType();
            Console.WriteLine("Enter the number of engines for your ariplane.");
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Enther the amount of engines in numbers!");
                input = Console.ReadLine();
            }
            int engines = int.Parse(input);
            Airplane airplane = new(regNmbr, colour, 6, engines);
            return airplane;
        }
        public void RemoveVehicle(Vehicle[] vehicles)
        {
            _parkingSpots = vehicles.Length;
            Console.WriteLine("Enter the spot number of the vehicle you want to remove. Between 1 and " + _parkingSpots);
            ShowVehicleSpots(vehicles.ToList());
            string? removeVehicle = Console.ReadLine();
            if(int.TryParse(removeVehicle, out int result))
                if(vehicles[result - 1] != null)
                {
                    vehicles[result - 1] = null;
                    Console.WriteLine("Vehicle removed from spot " + result);                    
                }
                else
                    Console.WriteLine("The spot is already empty!");
        }
        public void ShowVehicleSpots(List<Vehicle> vehicles)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"Spot {i + 1}: {(vehicles[i] != null ? vehicles[i].ToString() : "Empty")}");
            }
        }
        public Dictionary<string, int> ShowVehicleTypes(List<Vehicle>vehicles)
        {
            List<Vehicle> showAllVehicleTypes = ClearNullsInVehicleList(vehicles.ToArray());
            return showAllVehicleTypes.GroupBy(x => x.GetType().Name).ToDictionary(x => x.Key, x => x.Count());
        }
        public void ShowVehicles(List<Vehicle> vehicles)
        {
            List<Vehicle> showAllVehicles = ClearNullsInVehicleList(vehicles.ToArray());
            foreach (Vehicle item in showAllVehicles.OrderBy(x => x.GetType().Name))
            {
                Console.WriteLine(item.ToString());
            }
        }
        public List<Vehicle> RegisterNumberVehicleSearch(string search, Vehicle[] vehicles)
        {
            List<Vehicle> result = ClearNullsInVehicleList(vehicles);
            List<Vehicle> searchResult = result.Where(x => x.RegisterNumber == search.ToUpper()).ToList();
            return searchResult;
        }
        public List<Vehicle> ColourVehicleSearch(string search, Vehicle[] vehicles)
        {
            List<Vehicle> result = ClearNullsInVehicleList(vehicles);
            List<Vehicle> searchResult = result.Where(x => x.Colour == search.First().ToString().ToUpper() + search.Substring(1).ToLower()).ToList();
            return searchResult;
        }
        public List<Vehicle> AdvancedVehicleSearch(string search, Vehicle[] vehicles)
        {
            List<Vehicle> result = ClearNullsInVehicleList(vehicles);
            List<Vehicle> searchResult = new List<Vehicle>();
            var split = search.Split(' ');
            foreach (var item in result)
            {
                if(item is Car)
                {
                    for (int i = 0; i < split.Length; i++)
                    {
                        if(item.RegisterNumber == split[i].ToUpper() 
                        || item.Colour == split[i].First().ToString().ToUpper() + split[i].Substring(1).ToLower()
                        && search.Contains("car", StringComparison.OrdinalIgnoreCase))
                            searchResult.Add(item);
                    }
                }
                else if(item is Boat)
                {
                    for (int i = 0; i < split.Length; i++)
                    {
                       if(item.RegisterNumber == split[i].ToUpper() 
                        || item.Colour == split[i].First().ToString().ToUpper() + split[i].Substring(1).ToLower()
                        && search.Contains("boat", StringComparison.OrdinalIgnoreCase))
                            searchResult.Add(item);
                    }
                }
                else if(item is Bus)
                {
                    for (int i = 0; i < split.Length; i++)
                    {
                        if(item.RegisterNumber == split[i].ToUpper() 
                        || item.Colour == split[i].First().ToString().ToUpper() + split[i].Substring(1).ToLower()
                        && search.Contains("bus", StringComparison.OrdinalIgnoreCase))
                            searchResult.Add(item);
                    }
                }
                else if(item is Motorcycle)
                {
                    for (int i = 0; i < split.Length; i++)
                    {
                        if(item.RegisterNumber == split[i].ToUpper() 
                        || item.Colour == split[i].First().ToString().ToUpper() + split[i].Substring(1).ToLower()
                        && search.Contains("motorcycle", StringComparison.OrdinalIgnoreCase))
                            searchResult.Add(item);
                    }
                }
                else if(item is Airplane)
                {
                    for (int i = 0; i < split.Length; i++)
                    {
                        if(item.RegisterNumber == split[i].ToUpper() 
                        || item.Colour == split[i].First().ToString().ToUpper() + split[i].Substring(1).ToLower()
                        && search.Contains("airplane", StringComparison.OrdinalIgnoreCase))
                            searchResult.Add(item);
                    }
                }
            }
            return searchResult;
        }
        public void SearchVehicles(Vehicle[] vehicles)
        {
            menu.SearchMenu();
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out int result) && result < 1 || result > 3)
            {
                Console.WriteLine("Wrong input! Type a number between 1-3");
                input = Console.ReadLine();
            }
            int choice = int.Parse(input);
            switch (choice)
            {
                case 1:
                Vehicles = RedirectVehicleSearch(choice, vehicles);
                break;
                case 2:
                Vehicles = RedirectVehicleSearch(choice, vehicles);
                break;
                case 3:
                Vehicles = RedirectVehicleSearch(choice, vehicles);
                break;
                default:
                break;
            }

            Console.WriteLine("Search result: ");
            foreach (Vehicle item in Vehicles)
            {
                if(item != null)
                    Console.WriteLine(item.ToString());
            }
        }
        public string RegisterNumber()
        {
             Console.WriteLine("Enter the registernumber for your veichle.");
            string? regNmbr = Console.ReadLine();
            while (string.IsNullOrEmpty(regNmbr) || CheckRegisterNumber(regNmbr) == false)
            {
                Console.WriteLine("Enter a valid registernumber! e.g., ABC123");
                regNmbr = Console.ReadLine();
            }
            return regNmbr;
        }
        public bool CheckRegisterNumber(string regnumber)
        {

            if(regnumber.Length > 6 || regnumber.Length < 6)
                  return false;
            else if(Vehicles.Any(x => x.RegisterNumber == regnumber.ToUpper()))
            {
                Console.WriteLine($"{regnumber} already exist!");
                return false;
            }
            else
            {
                if(char.IsNumber(regnumber[0]) || char.IsNumber(regnumber[1]) || char.IsNumber(regnumber[2]))
                    return false;
                else if(!char.IsNumber(regnumber[3]) || !char.IsNumber(regnumber[4]) || !char.IsNumber(regnumber[5]))
                    return false;
                else
                    return true;               
            }
        }
        public List<Vehicle> RedirectVehicleSearch(int choice, Vehicle[] vehicles)
        {
            if(choice == 1)
            {
                Console.WriteLine("Type in a registernumber");
                string? input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Type in a registernumber! e.g., ABC123");
                    input = Console.ReadLine();
                }
                return RegisterNumberVehicleSearch(input, vehicles);
            }
            else if(choice == 2)
            {
                Console.WriteLine("Type in a colour");
                string? input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Type in a colour e.g., red");
                    input = Console.ReadLine();
                }
                return ColourVehicleSearch(input, vehicles);
            }
            else
            {
                Console.WriteLine("Type in what you are searching for");
                string? input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("What are you searching for?");
                    input = Console.ReadLine();
                }
                return AdvancedVehicleSearch(input, vehicles);               
            }
        }
        public string ColourType()
        {
            menu.ColourMenu();
            string? input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("What colour is your vehicle?");
                input = Console.ReadLine();
            }
            return input;
        }
        private List<Vehicle> ClearNullsInVehicleList(Vehicle[] vehicles)
        {
            List<Vehicle> removeNulls = vehicles.Where(x => x != null).ToList();
            return removeNulls;
        }
        private Vehicle ChooseVehicle(int choice) => choice switch
        {
            1 => AddNewCar(),
            2 => AddNewMotorcyle(),
            3 => AddNewBoat(),
            4 => AddNewBus(),
            5 => AddNewAirPlane(),
            _ => throw new Exception("Invalid input!")
        };
        private FuelType WhatFuel(int fueltype) => fueltype switch
        {
            1 => FuelType.Gasoline,
            2 => FuelType.Diesel,
            3 => FuelType.Electricity,
            _ => throw new Exception("Invalid entry!")
        };
    }
}