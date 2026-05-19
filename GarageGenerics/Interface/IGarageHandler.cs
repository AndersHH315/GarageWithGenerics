using System.Collections.Generic;
using GarageGenerics.VehicleType;

namespace GarageGenerics.Interface
{
    public interface IGarageHandler
    {
        List<Vehicle> AddSomeVehicle();
        string AddNewVehicle(Vehicle[] vehicles);
        Car AddNewCar();
        Bus AddNewBus();
        Boat AddNewBoat();
        Motorcycle AddNewMotorcyle();
        Airplane AddNewAirPlane();
        void RemoveVehicle(Vehicle[] vehicles);
        void ShowVehicleSpots(List<Vehicle> vehicles);
        Dictionary<string, int> ShowVehicleTypes(List<Vehicle>vehicles);
        void ShowVehicles(List<Vehicle> vehicles);
        List<Vehicle> RegisterNumberVehicleSearch(string search, Vehicle[] vehicles);
        List<Vehicle> ColourVehicleSearch(string search, Vehicle[] vehicles);
        List<Vehicle> AdvancedVehicleSearch(string search, Vehicle[] vehicles);
        void SearchVehicles(Vehicle[] vehicles);
        string RegisterNumber();
        bool CheckRegisterNumber(string regnumber);
        List<Vehicle> RedirectVehicleSearch(int choice, Vehicle[] vehicles);
        string ColourType();


    }
}