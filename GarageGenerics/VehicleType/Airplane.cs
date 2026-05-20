namespace GarageGenerics.VehicleType
{
    public class Airplane : Vehicle
    {
        private int _numberOfEngines;
        public int NumberOfEngines
        {
            get { return _numberOfEngines; }
            set
            {
                _numberOfEngines = value;
            }
        }
        public Airplane(string registerNumber, string colour, int wheels, int numberOfEngines) :base(registerNumber, colour, wheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return $"{Colour} Airplane, Registernumber: {RegisterNumber}, {Wheels}: Wheels, Amount of engines: {NumberOfEngines}.";
        }
    }
}