using System;
namespace TaxiPark.Containers
{
    public class DynamicContainer<T>
    {
        private T[] data;          
        private int size;          
        private int capacity;    

        public DynamicContainer(int initialCapacity = 4)
        {
            if (initialCapacity <= 0)
                throw new ArgumentException("Ёмкость должна быть положительным числом");

            capacity = initialCapacity;
            size = 0;
            data = new T[capacity];
        }
        public int Count => size;
        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return data[index];
            }
            set
            {
                ValidateIndex(index);
                data[index] = value;
            }
        }
        public void Add(T item)
        {
            if (size >= capacity)
            {
                ResizeContainer();
            }

            data[size] = item;
            size++;
        }
        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < size - 1; i++)
            {
                data[i] = data[i + 1];
            }

            size--;
            data[size] = default(T);
        }
        public void Insert(int index, T item)
        {
            if (index < 0 || index > size)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Индекс {index} вне диапазона [0, {size}]");

            if (size >= capacity)
            {
                ResizeContainer();
            }

            for (int i = size; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            data[index] = item;
            size++;
        }
        public void Clear()
        {
            data = new T[capacity];
            size = 0;
        }

        #region Private Methods

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= size)
                throw new ArgumentOutOfRangeException(nameof(index),
                    $"Индекс {index} вне диапазона [0, {size - 1}]");
        }
        private void ResizeContainer()
        {
            capacity *= 2;
            T[] newData = new T[capacity];
            Array.Copy(data, newData, size);
            data = newData;
        }

        #endregion
    }
}