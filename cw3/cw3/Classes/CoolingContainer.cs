using cw3.Interfaces;

namespace cw3.Classes;

public class CoolingContainer ( double height, double weight, double maxWeight, double depth, string product, double temp) : Container (height,weight,maxWeight,depth), IHazardNotifier
{
   private string _product = product;
   private double _temp = temp;
   private string _name = "KON-C-";
   private Dictionary<string, double> _productTemperatures = new Dictionary<string, double>
   {
      {"Bananas", 13.3},
      {"Chocolate", 18},
      {"Fish", 2},
      {"Meat", -15},
      {"Ice cream", -18},
      {"Frozen pizza", -30},
      {"Cheese", 7.2},
      {"Sausages", 5},
      {"Butter", 20.5},
      {"Eggs", 19}
   };
   
   void Pack(double cargo, string product)
   {
      if (product == _product)
      {
         if (_temp <= _productTemperatures[product] && cargo + CargoWeigth <= MaxWeight)
         {
            CargoWeigth += cargo;
         }
         else
         {
            SendWarning(SerialNumber);
         }
      }
      else
      {
         SendWarning(SerialNumber);
      }
      
   }
   public void SendWarning(int id)
   {
      Console.WriteLine($"Niebiezpieczna sytuacja (nieprawidłowy produkt lub temperatura) w kontenerze nr {id}, anulowano zaladunek !");
   }
   public override void GetInfo()
   {
      Console.WriteLine($"Kontener chłodniczy {_name}{SerialNumber} z produktem {_product} o temperaturze {_temp} stopni Celsjusza, zawartosc: {CargoWeigth}kg");
   }
}