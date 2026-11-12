namespace DeliveryDispatchEngine.models;

public class Queue<T>
{
    public int MaxItems {get; set;}
    public T[] Items {get; set;}
    public int Front {get; set;}
    public int Rear {get; set;}

    public Queue(int maxItems)
    {
        if (maxItems > 0)
        {
            MaxItems = maxItems;
            Items = new T[MaxItems];
            Front = 0;
            Rear = -1;
        }
        else
        {
            throw new ArgumentException("maxItems deve ser maior que zero.");
        }
    }

    public bool Enqueue(T item)
    {
        if (Rear < MaxItems -1)
        {
            Rear++;
            Items[Rear] = item;
            return true;
        }
        return false;
    }

    public T Dequeue()
    {
        if (Rear > -1)
        {
            T removed = Items[Front];

            int i, cur, next;
            for (i = Front; i < Rear; i++)
            {
                cur = i;
                next = i + 1;
                Items[cur] = Items[next];
            }
            Rear--;
            return removed;
        }
        throw new ArgumentException("A pilha está vazia");
    }

    public T CheckFirst()
    {
        return Items[Front];
    }

    public bool IsEmpty()
    {
        return Rear == -1;
    }
}