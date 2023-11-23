using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T> head;
    private int count;

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        count++;
    }

    public bool Remove(T data)
    {
        Node<T> current = head;
        Node<T> previous = null;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                if (previous == null)
                {
                    head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                count--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> linkedList = new LinkedList<int>();

        linkedList.Add(1);
        linkedList.Add(2);
        linkedList.Add(3);
        linkedList.Add(4);

        linkedList.Remove(2);

        Console.WriteLine("Elements in the linked list:");
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        var filteredList = linkedList.Where(item => item % 2 == 0);

        Console.WriteLine("\nFiltered elements in the linked list (even numbers):");
        foreach (var item in filteredList)
        {
            Console.WriteLine(item);
        }
    }
}