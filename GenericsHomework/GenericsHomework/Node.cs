
namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public void Append(T newValue)
    {
        if (Exists(newValue))
        {
            throw new ArgumentException("No Duplicates");
        }

        Node<T> newNode = new(newValue)
        {
            Next = this.Next
        };

        this.Next = newNode;
    }

    public bool Exists(T newValue)
    {
        Node<T> current = this;

        do
        {
            if (current.Value!.Equals(newValue))
            {
                return true;
            }
            current = current.Next;
        }
        while (current != this);

        return false;
    }

    public void Clear()
    {
        Node<T> current = Next;
        Node<T> temp;

        while (current != this)
        {
            temp = current.Next;
            current.Next = current;
            current = temp;
        }

        Next = this;
    }



    public override string? ToString()
    {
        return Value?.ToString();
    }

}

