using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Deques
{
    class ArrayDeque<T> : IDeque<T>
    {
        private T[] data;
        private int minCapacity;
        public int Size { get; private set; }

        public T Front { get {
            if (IsEmpty())
                throw new IndexOutOfRangeException();
            return data[0];
        } }

        public T Back { get {
            if (IsEmpty()) 
                throw new IndexOutOfRangeException();
            return data[Size - 1];
        } }

        public ArrayDeque(int capacity)
        {
            data = new T[capacity];
            minCapacity = capacity;
            Size = 0;
        }

        public bool IsEmpty() => Size == 0;

        public T PopBack()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Empty Queue");
            }

            T poppedElement = data[Size - 1];
            T[] arrayTemp = new T[Size - 1];

            Array.Copy(data, 0, arrayTemp, 0, --Size);
            Array.Copy(arrayTemp, data, Size);
            return poppedElement;
        }

        public string PopBack(int numberOfTimes)
        {
            T[] poppedElements = new T[numberOfTimes];

            for (int i = 0; i < numberOfTimes; i++)
            {
                poppedElements[i] = PopBack();
            }

            string data = string.Join(", ", poppedElements);

            return data;
        }

        public T PopFront()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Empty Queue");
            }

            if (((Size - 1) <= data.Length / 2) &&
                ((data.Length / 2) >= minCapacity))
            {
                Array.Resize<T>(ref data, data.Length / 2);
            }

            T poppedElement = data[0];
            T[] arrayTemp = new T[Size - 1];

            Array.Copy(data, 1, arrayTemp, 0, --Size);
            Array.Copy(arrayTemp, data, Size);

            return poppedElement;
        }

        public string PopFront(int numberOfTimes)
        {
            T[] poppedElements = new T[numberOfTimes];

            for (int i = 0; i < numberOfTimes; i++)
            {
                poppedElements[i] = PopFront();
            }

            string data = string.Join(", ", poppedElements);

            return data;
        }

        public void PushBack(T element)
        {

            if (Size == data.Length)
            {
                Array.Resize<T>(ref data, data.Length * 2);
            }

            data[Size++] = element;
        }

        public void PushBack(params T[] elements)
        {
            Array.ForEach(elements, e => PushBack(e));
        }

        public void PushFront(T element)
        {
            if (IsEmpty())
                data[Size++] = element;

            else
            {
                T[] arrayTemp = new T[Size + 1];

                Array.Copy(data, 0, arrayTemp, 1, Size);
                Array.Copy(arrayTemp, data, ++Size);

                data[0] = element;
            }
        }
        public override string ToString()
        {
            string debug = $"[C:{data.Length} S:{Size} Empty:{IsEmpty()}]";

            debug += " { ";
            for (int i = 0; i < Size; ++i)
            {
                debug += $"{data[i]}, ";
            }
            debug += "}";

            return debug;
        }
    }
}
