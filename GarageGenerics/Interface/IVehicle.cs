using System.Dynamic;

namespace GarageGenerics.Interface
{
    public interface IVehicle
    {
        string? RegisterNumber { get; set; }
        string? Colour { get; set; }
        int Wheels { get; set; }
    }

}