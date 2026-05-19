namespace GarageGenerics.VehicleType
{
    public class Bus : Vehicle
    {
        private int _numberOfSeats;
        public int NumberOfSeats
        {
            get { return _numberOfSeats; }
            set
            {
                _numberOfSeats = value;
            }
        }
        public Bus(string registerNumber, string colour, int wheels, int numberOfSeats) :base(registerNumber, colour, wheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{Colour} Bus, Registernumber: {RegisterNumber}, Number of seats: {NumberOfSeats}.";
        }
    }
}