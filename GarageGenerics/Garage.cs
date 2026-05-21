using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GarageGenerics.Handler;
using GarageGenerics.VehicleType;

namespace GarageGenerics
{
    public class Garage<T>: IEnumerable<T> where T : Vehicle
    {
        private Vehicle[] _vehicles;
        private int _parkingSpots;
        GarageHandler garageHandler = new();
        public int ParkingSpots
        {
            get { return _parkingSpots; }
            set
            {
                _parkingSpots = value;
            }
        }
        public Garage(int parkingSpots)
        {
            ParkingSpots = parkingSpots;
            _vehicles = new Vehicle[ParkingSpots];
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _vehicles)
            {
                if(item is not null)
                    yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void ParkVehicles()
        {
            if(_vehicles.Length > 8)
            {
                Console.WriteLine("Do you want to add some vehicles to the garage? (y/n)");
                string? addVehicles = Console.ReadLine();
                while (addVehicles != "y" && addVehicles != "n")
                {
                    Console.WriteLine("Invalid input! Please enter 'y' or 'n'");
                    addVehicles = Console.ReadLine();
                }
                if(addVehicles == "y")
                {
                    var newVehicles = garageHandler.AddSomeVehicle(_vehicles);

                    for (int i = 0; i < newVehicles.Length; i++)
                    {
                        _vehicles[i] = newVehicles[i];
                    }

                }
                else
                    Console.WriteLine("Okay, no vehicles will be added to the garage!");
            }
        }
        public void ParkNewVehicle()
        {
            garageHandler.AddNewVehicle(_vehicles);
        }

        public void UnParkVehicle()
        {
            garageHandler.RemoveVehicle(_vehicles);
        }

    }
}