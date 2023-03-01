using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{

    public class Node
    {
        public T Value;
        public Node? Next;
        public Node? Previous;

        public Node(T value, Node? next, Node? prev)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = prev;
        }
    }

    private Node? head;
    private Node? tail;

    public int Count { get; private set; } = 0;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        Count = 0;
    }

    public bool IsEmpty()
    {
        return Count <= 0;
    }

    public bool Contains(T value)
    {
        if (IsEmpty())
        {
            return false;
        }
        Node? tmp = head;
        while (tmp != null && tmp.Value != null)
        {
            if (tmp.Value.Equals(value))
            {
                return true;
            }
            tmp = tmp.Next;
        }
        return false;
    }

    public T? Get(int index)
    {
        if (IsEmpty() || Count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        Node? current = head;
        int currentIndex = 0;

        while (current != null && currentIndex <= index)
        {
            if (currentIndex == index)
            {
                return current.Value;
            }
            else
            {
                currentIndex++;
                current = current.Next;
            }
        }
        return default(T);
    }

    public T? GetFirst()
    {
        if (head != null)
        {
            return head.Value;
        }
        return default(T);
    }

    public T? GetLast()
    {
        if (tail != null)
        {
            return tail.Value;

        }
        return default(T);
    }

    public void AddLast(T value)
    {
        if (IsEmpty())
        {
            Node tmp = new Node(value, null, null);
            head = tmp;
            tail = tmp;
            Count++;
            return;
        }
        else
        {
            Node? tmp = tail;
            tmp.Next = new Node(value, null, tmp);
            tail = tmp.Next;
            Count++;

        }

    }

    public void AddFirst(T value)
    {
        if (IsEmpty())
        {
            var tmp = new Node(value, null, null);
            head = tmp;
            tail = tmp;
            Count++;
            return;
        }
        else
        {
            var tmp = new Node(value, null, null);
            tmp.Next = head;
            if (head is not null)
            {
                head.Previous = tmp;
            }
            head = tmp;
            Count++;
        }
    }

    public void AddAfter(T key, T toAdd)
    {
        if (IsEmpty())
        {
            throw new KeyNotFoundException();
        }
        Node tmp = head;
        while (tmp != null)
        {
            if (tmp.Value.Equals(key))
            {
                Node? newNode = new Node(toAdd, tmp.Next, tmp);
                tmp.Next = newNode;

                if (newNode.Next != null) newNode.Next.Previous = newNode;
                else tail = newNode;
                Count++;
                return;
            }
            tmp = tmp.Next;
        }

        throw new KeyNotFoundException();
    }

    public void AddBefore(T key, T toAdd)
    {
        if (IsEmpty())
        {
            throw new KeyNotFoundException();
        }
        Node tmp = head;
        while (tmp != null)
        {
            if (tmp.Value.Equals(key))
            {
                Node newNode = new Node(toAdd, tmp, tmp.Previous);
                tmp.Previous = newNode;

                if (newNode.Previous != null) newNode.Previous.Next = newNode;
                else head = tmp.Previous;
                Count++;
                return;
            }
            tmp = tmp.Next;
        }

        throw new KeyNotFoundException();
    }

    public void Remove(T value)
    {
        if (IsEmpty())
        {
            return;
        }
        Node tmp = head;
        while (tmp != null)
        {
            if (tmp.Value.Equals(value))
            {
                if (tmp.Previous != null) tmp.Previous.Next = tmp.Next;
                else head = tmp.Next;
                if (tmp.Next != null) tmp.Next.Previous = tmp.Previous;
                else tail = tmp.Previous;
                Count--;
            }
            tmp = tmp.Next;
        }
        return;
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            return;
        }
        if (Count == 1)
        {
            head = null;
            tail = null;
            Count--;
            return;
        }
        head = head.Next;
        head.Previous = null;
        Count--;
    }

    public void RemoveLast()
    {
        if (IsEmpty())
        {
            return;
        }
        if (Count == 1)
        {
            head = null;
            tail = null;
            Count--;
            return;
        }
        tail = tail.Previous;
        tail.Next = null;
        Count--;
    }

    public int IndexOf(T value)
    {
        int index = 0;
        Node tmp = head;
        while (tmp != null)
        {
            if (tmp.Value.Equals(value))
            {
                return index;
            }
            tmp = tmp.Next;
            index++;
        }
        return -1;
    }

    public void Clear()
    {
        this.Count = 0;
        this.head = null;
        this.tail = null;
    }
    override public string ToString()
    {
        string res = "{";
        Node? tmp = head;
        while (tmp != null)
        {
            res += tmp.Value.ToString();
            if (tmp.Next != null) res += ", ";
            tmp = tmp.Next;
        }
        res += "}";
        return res;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node? node = head;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
