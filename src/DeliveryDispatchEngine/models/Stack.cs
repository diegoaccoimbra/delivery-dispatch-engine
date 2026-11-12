namespace DeliveryDispatchEngine.models;

public class Stack<T>
{
    public int MaxItems {get; set;}
    public T[] Items {get; set;}
    public int Top {get; set;}
    
    public Stack(int maxItems)
    {
        if (maxItems > 0)
        {
            MaxItems = maxItems;
            Top = -1;
            Items = new T[maxItems];
        }
        else
        {
            throw new ArgumentException("maxItems deve ser maior que zero.");
        }
    }

    public bool Push(T item)
    {
        if (Top < MaxItems - 1)
        {
            Top++;
            Items[Top] = item;
            return true;
        }
        return false;
    }

    public T Pop()
    {
        if (Top > -1)
        {
            T removed = Items[Top];
            Items[Top] = default!;
            Top--;
            return removed;
        }
        else
        {
            throw new ArgumentException("A pilha está vazia");
            //return null;
        }
    }

    public bool IsEmpty()
    {
        return Top < 0;
    }

    public T CheckTop()
    {
        return Items[Top];
    }
}