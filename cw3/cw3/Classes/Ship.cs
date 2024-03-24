using cw3.Exception;

namespace cw3.Classes;

public class Ship(double maxspeed, int maxload, double maxweight): OverfillException
{
    public List<Container> Containers = new List<Container>();
    public double MaxSpeed = maxspeed;
    public int MaxLoad = maxload;
    public double MaxWeight = maxweight;
    public double Weight = 0;
    public int ContainersCount = 0;
    public int Id = _nextid++;
    private static int _nextid = 1;

    public void PackOnShip(Container container)
    {
        if (Weight + container.Weight <= MaxWeight && Containers.Count + 1 <= MaxLoad)
        {
            Containers.Add(container);
            Weight += container.Weight;
            ContainersCount++;
            Console.WriteLine("Pomyslnie zaladowano kontener na statek");
        }
        else
        {
            throw new OverfillException("Statek pełny");
        }
    }

    public void PackOnShip(List<Container> containers)
    {
        foreach (Container container in containers)
        {
            if (Weight + container.Weight <= MaxWeight && Containers.Count + 1 <= MaxLoad)
            {
                Containers.Add(container);
                Weight += container.Weight;
                ContainersCount++;
                Console.WriteLine("Pomyslnie zaladowano kontener na statekl");
            }
            else
            {
                Console.WriteLine("Nie mozna zaladowac kontenerów na statek, limi wagi lub pakowności przekroczony");
            }
        }
    }

    public void ContainerUnpack(int id)
    {
        for (int i = Containers.Count - 1; i >= 0; i--)
        {
            if (Containers[i].SerialNumber == id)
            {
                Weight -= Containers[i].Weight;
                ContainersCount--;
                Containers.RemoveAt(i);
                    
                Console.WriteLine("Usunięto kontener ze statku");
                return; 
            }
        }
        Console.WriteLine("Kontener o podanym ID nie został znaleziony.");
    }

    public void SwapContainers(Container onShip, Container toPlace)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == onShip.SerialNumber);
    
        if (index != -1) 
        {
            Containers[index] = toPlace; 
            Console.WriteLine("Kontener został wymieniony.");
            Weight += toPlace.Weight - onShip.Weight;
            
        }
        else
        {
            Console.WriteLine("Kontener nie został znaleziony na statku.");
        }
    }

    public void TransferBetweenShips(Container toTransfer, Ship ship2)
    {
       
        if (!Containers.Any(c => c.SerialNumber == toTransfer.SerialNumber))
        {
            Console.WriteLine("Kontener nie znajduje się na statku.");
            return;
        }
        
        try
        {
            ship2.PackOnShip(toTransfer);
            Containers.Remove(toTransfer);
            Weight -= toTransfer.Weight;
            ContainersCount--;
            Console.WriteLine("Transfer udany.");
        }
        catch (OverfillException)
        {
            Console.WriteLine("Nie można dokonać transferu: statek docelowy przekroczył dopuszczalną ładowność.");
        }
    }
    public void GetShipInfo()
    {
        Console.WriteLine($"Statek o numerze {Id} o maksymalnej prędkości {MaxSpeed} km/h, maksymalnym ładunku {MaxLoad} i maksymalnej wadze {MaxWeight} waży {Weight} i ma na pokładzie {Containers.Count} kontenerów");
        Console.WriteLine("lista kontenerów na statku:");
        foreach (Container container in Containers)
        {
            container.GetInfo();
        }
    }
}