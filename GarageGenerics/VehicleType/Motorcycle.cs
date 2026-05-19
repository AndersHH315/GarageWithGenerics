using System.Runtime.CompilerServices;

namespace GarageGenerics.VehicleType
{
    public class Motorcycle : Vehicle
    {
        private int _cylinderVolume;
        public int CylinderVolume
        {
            get { return _cylinderVolume; }
            set
            {
                _cylinderVolume = value;
            }
        }
        public Motorcycle(string registerNumber, string colour, int wheels, int cylinderVolume) :base(registerNumber, colour, wheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return $"{Colour} Motorcycle, Registernumber: {RegisterNumber}, Amount of cylinders: {CylinderVolume}.";
        }
    }
}