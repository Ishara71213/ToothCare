using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.DataStructures
{
    internal class DoublyListNode<T>
    {
        public T Data { get; set; }
        public DoublyListNode<T>? Next { get; set; }
        public DoublyListNode<T>? Previous { get; set; }

        internal DoublyListNode(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    public class DoublyLinkedList<T>
    {
        private DoublyListNode<T>? head;
        private DoublyListNode<T>? tail;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public void AddToFront(T data)
        {
            DoublyListNode<T> newNode = new DoublyListNode<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            count++;
        }

        public void AddToEnd(T data)
        {
            DoublyListNode<T> newNode = new DoublyListNode<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }

            count++;
        }

        public void AddToPosition(int index, T data)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            }

            if (index == 0)
            {
                AddToFront(data);
            }
            else if (index == count)
            {
                AddToEnd(data);
            }
            else
            {
                DoublyListNode<T> newNode = new DoublyListNode<T>(data);
                DoublyListNode<T> current = head!;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next!;
                }

                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next!.Previous = newNode;
                current.Next = newNode;

                count++;
            }
        }

        public T? GetFirst()
        {
            if (count == 0)
            {
                return default;
            }

            return head!.Data;
        }

        public T? GetLast()
        {
            if (count == 0)
            {
                return default;
            }

            return tail!.Data;
        }

        public DoublyLinkedList<T> Where(Func<T, bool> predicate)
        {
            DoublyLinkedList<T> result = new DoublyLinkedList<T>();
            DoublyListNode<T>? current = head;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    result.AddToEnd(current.Data);
                }

                current = current.Next;
            }

            return result;
        }

    }
}
