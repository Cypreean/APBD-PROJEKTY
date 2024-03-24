using cw3.Interfaces;

namespace cw3.Classes;

public class GasContainer ( double height, double weight, double maxWeight, double depth, int pressure) : Container (height,weight,maxWeight,depth), IHazardNotifier
{
   private int _pressure = pressure;
   private string _name = "KON-G-";

   public override void Unpack()
   {
      CargoWeigth = CargoWeigth * 0.05;
   }

   public void SendWarning(int id)
   {
      Console.WriteLine($"Niebiezpieczna sytuacja w kontenerze nr {id}, anulowano zaladunek !");
   }
   public override void GetInfo()
   {
      Console.WriteLine($"Kontener gazowy {_name}{SerialNumber} o cisnieniu {_pressure} bar, zawartosc: {CargoWeigth} kg");
   }
}