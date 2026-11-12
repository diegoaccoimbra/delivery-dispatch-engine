using DeliveryDispatchEngine.models;

DispatchCenter dispatchCenter = new DispatchCenter(3);

// Pacotes
Package package1 = new Package(1, "A", 5.0f, false);
Package package2 = new Package(2, "B", 2.4f, true);
Package package3 = new Package(3, "C", 1.0f, true);

// Lista de despacho
List<Package> myList = new List<Package>();

// Mochila com capacidade de 10 kg
DeliveryBackpack deliveryBackpack = new DeliveryBackpack(10);

// Adicionando os pacotes na lista de despacho
myList.Add(package1);
myList.Add(package2);
myList.Add(package3);

dispatchCenter.ReceivePackages(myList, deliveryBackpack);

dispatchCenter.LoadDeliveryBackpack(deliveryBackpack, dispatchCenter.PackageQueue);

dispatchCenter.SimulateDelivery(deliveryBackpack);