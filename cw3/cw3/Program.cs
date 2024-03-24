using cw3.Classes;

namespace cw3;

public class Program
{
    public static void Main(string[] args)
    {
        CoolingContainer coolingContainer = new CoolingContainer(10, 10, 40, 20, "Fish", 1);
        LiquidContainer liquidContainer2 = new LiquidContainer(10, 10, 40, 20, true);
        liquidContainer2.GetInfo();
        Ship ship = new Ship(10, 10, 100 );
        coolingContainer.Pack(25);
        ship.PackOnShip(coolingContainer);
        ship.GetShipInfo();
        Console.WriteLine("Pakowanie listy kontenerów na statek:");
        List<Container> containers = new List<Container>();
        containers.Add(liquidContainer2);
        liquidContainer2.Pack(5);
        ship.PackOnShip(containers);
        ship.GetShipInfo();
        Console.WriteLine("Rozpakowywanie kontenera z statku:");
        ship.ContainerUnpack(1);
        ship.GetShipInfo();
        Console.WriteLine("Zamiana kontenerów na statku:");
        ship.SwapContainers(liquidContainer2, coolingContainer);
        ship.GetShipInfo();
        Console.WriteLine("Przenoszenie kontenerów między statkami:");
        Ship ship2 = new Ship(10, 20, 400);
        ship.TransferBetweenShips(coolingContainer, ship2);
        ship.GetShipInfo();
        ship2.GetShipInfo();

    }
}