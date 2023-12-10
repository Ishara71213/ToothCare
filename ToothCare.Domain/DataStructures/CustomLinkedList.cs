using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.DataStructures
{
    
    public class CustomLinkedList<T> : IList<T>
    { 
        private Node<T>? head;
        private int count;

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return GetNode(index)!.Data;
            }
            set
            {
                ValidateIndex(index);
                GetNode(index)!.Data = value;
            }
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (head == null)
            {
                head = new Node<T>(item);
            }
            else
            {
                Node<T> lastNode = GetLastNode()!;
                lastNode.Next = new Node<T>(item);
            }

            count++;
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

            Node<T> lastNode = GetLastNode()!;
            return lastNode.Data;
        }

        public override string ToString()
        {
            return string.Join(", ", this.Take(count));
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Node<T>? current = head;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public CustomLinkedList<T> Where(Func<T, bool> predicate)
        {
            CustomLinkedList<T> result = new CustomLinkedList<T>();
            Node<T>? current = head;

            while (current != null)
            {
                if (predicate(current.Data))
                {
                    result.Add(current.Data);
                }

                current = current.Next;
            }

            return result;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Index is out of range.");
            }

            if (array.Length - arrayIndex < count)
            {
                throw new ArgumentException("Destination array dose n't have space enough to copy items.");
            }

            Node<T>? current = head;
            int currentIndex = arrayIndex;

            while (current != null)
            {
                array[currentIndex] = current.Data;
                current = current.Next;
                currentIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public int IndexOf(T item)
        {
            Node<T>? current = head;
            int index = 0;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndexForInsert(index);

            if (index == 0)
            {
                Node<T> newNode = new Node<T>(item);
                newNode.Next = head!;
                head = newNode;
            }
            else
            {
                Node<T> previousNode = GetNode(index - 1)!;
                Node<T> newNode = new Node<T>(item);
                newNode.Next = previousNode!.Next;
                previousNode.Next = newNode;
            }

            count++;
        }

        public bool Remove(T item)
        {
            Node<T>? current = head;
            Node<T>? previous = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, item))
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

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            if (index == 0)
            {
                head = head!.Next;
            }
            else
            {
                Node<T> previousNode = GetNode(index - 1)!;
                previousNode.Next = previousNode.Next?.Next!;
            }

            count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T>? GetNode(int index)
        {
            ValidateIndex(index);

            Node<T>? current = head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current;
        }

        private Node<T>? GetLastNode()
        {
            Node<T>? current = head;

            while (current?.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        private void ValidateIndexForInsert(int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Out of range Insert to the Index");
            }
        }


    }
}
