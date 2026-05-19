using GarageGenerics.VehicleType.VehicleParts;

namespace GarageGenerics.VehicleType
{
    public class Car : Vehicle
    {
        private FuelType _fuelType;
        public FuelType FuelType
        {
            get { return _fuelType; }
            set
            {
                _fuelType = value;
            }
        }
        public Car(string registerNumber, string colour, int wheels, FuelType fuelType) :base(registerNumber, colour, wheels)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        { 
            return $"{Colour} Car, Registernumber: {RegisterNumber}, Fueltype: {FuelType}.";
        }
    }
}