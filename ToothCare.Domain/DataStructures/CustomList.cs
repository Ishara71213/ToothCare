using System;
using System.Collections;
using System.Diagnostics;

namespace ToothCare.Domain.DataStructures
{
    public class CustomList<T> : IList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int count;

        private static readonly T[] s_emptyArray = new T[0];

        public CustomList()
        {
            items = s_emptyArray;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            { 
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public void Add(T item)
        {  
            EnsureCapacity();
            items[count] = item;
            count++;
        }

        public T? GetFirst()
        {
            if (count == 0)
            {
                return default;
            }

            return items[0];
        }

        public T? GetLast()
        {
            if (count == 0)
            {
                return default;
            }

            return items[count - 1];
        }

        public CustomList<T> Where(Func<T, bool> predicate)
        {
            CustomList<T> result = new CustomList<T>();

            for (int i = 0; i < count; i++)
            {
                if (predicate(items[i]))
                {
                    result.Add(items[i]);
                }
            }

            return result;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndexToInsert(index);
            EnsureCapacity();

            // Shift elements to make space for the new item
            Array.Copy(items, index, items, index + 1, count - index);

            // Insert new item
            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            // Shift elements to remove the specific item
            Array.Copy(items, index + 1, items, index, count - index - 1);

            // Set last element to default of the type
            items[count - 1] = default!;

            count--;
        }

        public void Clear()
        {
            items = s_emptyArray; // Reset  array to empty
            count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(items[i], default(T)))
                {
                    yield return items[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        private void EnsureCapacity()
        {
            if (count == items.Length)
            {
                // Double the capacity when count is equals to the current capacity
                //Since using the iterable inserts to the array it better to keep extra space
                //other wise have to add extra space for each insert
                int newCapacity = Math.Max(items.Length * 2, DefaultCapacity);
                Array.Resize(ref items, newCapacity);
            }
        }

        private void ValidateIndexToInsert(int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Index is out of range for insertion.");
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this.Take(count));
        }
    }
}
