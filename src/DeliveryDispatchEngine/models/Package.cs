namespace DeliveryDispatchEngine.models;

public class Package(int id, string address, float weight, bool priority)
{
    public int Id {get; set;} = id;
    public string Address {get; set;} = address;
    public float Weight {get; set;} = weight;
    public bool IsPriority {get; set;} = priority;
    public bool ReceivedAtDispatchCenter {get; set;} = false;
}