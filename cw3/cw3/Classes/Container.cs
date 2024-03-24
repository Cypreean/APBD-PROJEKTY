using System.Runtime.CompilerServices;
using cw3.Exception;

namespace cw3.Classes;

public abstract class Container( double height, double weight, double maxWeight, double depth)
{
    public double CargoWeigth = 0;
    public double Height = height;
    public double Weight = weight;
    public double MaxWeight = maxWeight;
    public double Depth = depth;
    public int SerialNumber { get; } = _nextSeialNumber++;
    private static int _nextSeialNumber = 1;
   

    public virtual void Unpack()
    {
        CargoWeigth = 0;
    }

    public virtual void Pack(double cargo)
    {   
        double newWeight = CargoWeigth + cargo;
        if (newWeight > MaxWeight)
        {
            throw new OverfillException(
                $"Nie mozna zapakowac ladunku, poniewaz przekracza on dopuszczalna mase {MaxWeight} o {newWeight - MaxWeight}");
        }
        CargoWeigth += cargo;
    }
    public virtual void GetInfo()
    {
        Console.WriteLine($"Kontener o numerze seryjnym {SerialNumber} o wymiarach {Height}x{Weight}x{Depth} zawartosc: {CargoWeigth}kg");
    }
    
}