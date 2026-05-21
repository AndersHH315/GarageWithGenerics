using System.Collections.Generic;
using GarageGenerics.VehicleType;

namespace GarageGenerics.Interface
{
    public interface IGarageHandler
    {
        void RunGarage();
        Vehicle[] AddSomeVehicle(Vehicle[] vehicles);
        string AddNewVehicle(Vehicle[] vehicles);
        Car AddNewCar();
        Bus AddNewBus();
        Boat AddNewBoat();
        Motorcycle AddNewMotorcyle();
        Airplane AddNewAirPlane();
        void RemoveVehicle(Vehicle[] vehicles);
        void ShowVehicleSpots(List<Vehicle> vehicles);
        void ShowVehicleTypes(Garage<Vehicle>vehicles);
        void ShowVehicles(Garage<Vehicle> vehicles);
        List<Vehicle> RegisterNumberVehicleSearch(string search, Garage<Vehicle>vehicles);
        List<Vehicle> ColourVehicleSearch(string search, Garage<Vehicle>vehicles);
        List<Vehicle> AdvancedVehicleSearch(string search, Garage<Vehicle>vehicles);
        void SearchVehicles(Garage<Vehicle>vehicles);
        string RegisterNumber();
        bool CheckRegisterNumber(string regnumber);
        List<Vehicle> RedirectVehicleSearch(int choice, Garage<Vehicle>vehicles);
        string ColourType();
        int AmountOfWheels();


    }
}