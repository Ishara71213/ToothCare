using System;
using System.Collections;
using System.Collections.Generic;

public class CustomArray<T> : IEnumerable<T>
{
    private T[] array;
    private int length;

    public int Length
    {
        get { return length; }
    }

    public CustomArray(int size)
    {
        if (size < 0)
        {
            throw new ArgumentException("Expect non-negative Size.");
        }

        array = new T[size];
        length = size;
    }

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            return array[index];
        }
        set
        {
            ValidateIndex(index);
            array[index] = value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < length; i++)
        {
            yield return array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= length)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }
}