using System.Linq;
using GarageGenerics.Interface;

namespace GarageGenerics.VehicleType
{
    public class Vehicle : IVehicle
    {
        private string? _regNumber;
        private string? _colour;
        private int _wheels;

        public string? RegisterNumber
        {
            get { return _regNumber.ToUpper(); }
            set
            {
                _regNumber = value;
            }

        }
        public string? Colour
        {
            get { return _colour.First().ToString().ToUpper() + _colour.Substring(1) ; }
            set
            {
                _colour = value;
            }
        }
        public int Wheels
        {
            get { return _wheels; }
            set
            {
                _wheels = value;
            }
        }
        public Vehicle(string registerNumber, string color, int wheels)
        {
            RegisterNumber = registerNumber;
            Colour = color;
            Wheels = wheels;
        }
        public virtual new string ToString()
        {
            return $"RegNumber: {RegisterNumber}, Color: {Colour}, Wheels: {Wheels}";
        }
    }
}