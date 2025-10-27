namespace Lists;

//TODO #1: Copy your List<T> class (List.cs) to this project and overwrite this file.
using Lists;
using System.Collections;

public class ListNode<T>
{
    public T Value;
    public ListNode<T> Next = null;

    

    public ListNode(T value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public class List<T> : IList<T>
{
    ListNode<T> First = null;
    ListNode<T> Last = null;
    int m_numItems = 0;

    public override string ToString()
    {
        ListNode<T> node = First;
        string output = "[";

        while (node != null)
        {
            output += node.ToString() + ",";
            node = node.Next;
        }
        output = output.TrimEnd(',') + "] " + Count() + " elements";

        return output;
    }

    public int Count()
    {
        //TODO #1: return the number of elements on the list
        
        return m_numItems;
        
    }

    public T Get(int index)
    {
        //TODO #2: return the element on the index-th position. O if the position is out of bounds
        int position = 0;
            ListNode<T> node = First;
            while (node != null)
            {
                if (position == index)
                {
                    return node.Value;
                }
                node = node.Next;
                position++;
            }
        return default(T);
        
    }

    public void Add(T value)
    {
        //TODO #3: add a new integer to the end of the list
        ListNode<T> newNode = new ListNode<T>(value);

        ListNode<T> nodeLast = Last;
        if (First == null)
        {
            First = newNode;


        }
        else if (First.Next != null)
        {
            nodeLast.Next = newNode;

        }
        else
            First.Next = newNode;
        m_numItems++;
        Last = newNode;
    }

    public T Remove(int index)
    {
        //TODO #4: remove the element on the index-th position. Do nothing if position is out of bounds
        if (index == 0)
        {
            First = First.Next;
            m_numItems--;
            return First.Value;
            
            }
        if (index == Count() - 1)
        {

            T lastElement = Last.Value;
            ListNode<T> node = First;
            
            m_numItems--;
            for (int i = 0; i < m_numItems - 1; i++)
                {
                    node = node.Next;
                }
            Last = node;
            return lastElement;

            }
        else if (index > 0 && index < Count() - 1)
        {
            ListNode<T> node = First;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            T devolver = node.Next.Value;
            node.Next = node.Next.Next;
            m_numItems--;
            return devolver;
        }
                return default(T);
        
        
        
    }

    public void Clear()
    {
        //TODO #5: remove all the elements on the list
        First = null;
        m_numItems = 0;
        
    }

    public IEnumerator GetEnumerator()
    {
        //TODO #6 : Return an enumerator using "yield return" for each of the values in this list
        
        ListNode<T> node = First;
            
            if (First != null)
            {

                for (int i = 0; i < m_numItems; i++)
                {

                    yield return node.Value;
                    node = node.Next;

                }
            }
            else
            {
                yield return null;
            }
        
    }
}