namespace DeliveryDispatchEngine.models;

public class DispatchCenter(int numberOfPackages)
{
    public Queue<Package> PackageQueue {get; set;} = new Queue<Package>(numberOfPackages);    
    public List<Package> DeliveryList {get; set;} = new List<Package>();

    // Recebe a lista de pacotes na central a serem despachados pelo entregador. São verificados se são pacotes prioritários e se cabem na mochila do entregador.
    public void ReceivePackages(List<Package> packageList, DeliveryBackpack deliveryBackpack)
    {
        // Primeiro adiciona os pacotes com prioridade
        for (int i = 0; i < packageList.Count; i++)
        {
            if (packageList[i].IsPriority && packageList[i].Weight <= deliveryBackpack.MaxCapacity - deliveryBackpack.CurrentWeight)
            {
                AddPackage(packageList[i], deliveryBackpack);
            }
        }

        // Se ainda há espaço na mochila, adiciona os pacotes que não são prioridade
        if (deliveryBackpack.CurrentWeight < deliveryBackpack.MaxCapacity)
        {
            for (int i = 0; i < packageList.Count; i++)
            {
                if (!packageList[i].ReceivedAtDispatchCenter && packageList[i].Weight <= deliveryBackpack.MaxCapacity - deliveryBackpack.CurrentWeight)
                {
                    AddPackage(packageList[i], deliveryBackpack);
                }
            }
        }
    }

    // Adiciona o pacote na fila
    public void AddPackage(Package package, DeliveryBackpack deliveryBackpack)
    {
        PackageQueue.Enqueue(package);
        deliveryBackpack.CurrentWeight += package.Weight;
        package.ReceivedAtDispatchCenter = true;
        Console.WriteLine($"Package {package.Id} received at the dispatch center.");
    }

    // Desinfileira os pacotes e adiciona na lista de entrega para serem empilhados na mochila do entregador com base na ordem de entrega.
    public void LoadDeliveryBackpack(DeliveryBackpack deliveryBackpack, Queue<Package> PackageQueue)
    {
        while (!PackageQueue.IsEmpty())
        {
            Package package = PackageQueue.Dequeue();
            DeliveryList.Add(package);
            Console.WriteLine($"Package {package.Id} added to the delivery list.");
        }

        for (int i = DeliveryList.Count - 1; i >= 0; i--)
        {
            deliveryBackpack.Backpack.Push(DeliveryList[i]);
            Console.WriteLine($"Package {DeliveryList[i].Id} loaded into the backpack.");
        }
    }

    // Retira os pacotes da mochila do entregador de acordo com a ordem de prioridade da entrega.
    public void SimulateDelivery(DeliveryBackpack deliveryBackpack)
    {
        while (!deliveryBackpack.Backpack.IsEmpty())
        {
            Package removedPackage = deliveryBackpack.Backpack.Pop();
            deliveryBackpack.CurrentWeight -= removedPackage.Weight;
            Console.WriteLine($"Package {removedPackage.Id} delivered.");
        }
    }
}