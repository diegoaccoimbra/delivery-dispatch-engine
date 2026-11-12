using System.Dynamic;

namespace DeliveryDispatchEngine.models;

public class DeliveryBackpack(int maxCapacity)
{
    public int MaxCapacity {get; set;} = maxCapacity;
    public float CurrentWeight {get; set;} = 0.0f;
    public Stack<Package> Backpack {get; set;} = new Stack<Package>(maxCapacity);
}