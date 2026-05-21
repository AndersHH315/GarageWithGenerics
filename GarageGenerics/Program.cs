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
            garageHandler.RunGarage();
        }
    }
}