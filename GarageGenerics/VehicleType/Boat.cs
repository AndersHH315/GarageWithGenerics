namespace GarageGenerics.VehicleType
{
    public class Boat : Vehicle
    {
        private int _length;
        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
            }
        }
        public Boat(string registerNumber, string colour, int wheels, int length) :base(registerNumber, colour, wheels)
        {
            Length = length;
        }

        public override string ToString()
        {
            return $"{Colour} Boat, Registernumber: {RegisterNumber}, The boat length: {Length}m.";
        }
    }
}