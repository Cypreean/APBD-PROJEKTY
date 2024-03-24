using cw3.Interfaces;

namespace cw3.Classes;

public class LiquidContainer ( double height, double weight, double maxWeight, double depth , bool danger) : Container (height,weight,maxWeight,depth), IHazardNotifier
{
    private bool _danger = danger;
    private string _name = "KON-L-";

    public override void Pack(double cargo)
    {
        if ((CargoWeigth + cargo > MaxWeight * 0.5 && _danger )||(CargoWeigth + cargo > MaxWeight *0.9 && !_danger))
        {
           
            SendWarning(SerialNumber);
        }
        
    }

    public void SendWarning(int id)
    {
        Console.WriteLine($"Niebiezpieczna sytuacja w kontenerze nr {id}, anulowano zaladunek !");
    }
    public override void GetInfo()
    {
        Console.WriteLine($"Kontener ciekly {_name}{SerialNumber} o zawartosci {CargoWeigth} kg");
    }
    
}