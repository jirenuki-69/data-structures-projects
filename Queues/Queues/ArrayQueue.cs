using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class ArrayQueue<T> : IQueue<T>
    {
        private T[] data;
        private int minCapacity;
        public int Size { get; private set; }

        public T Head { get {
            if (IsEmpty())
                throw new IndexOutOfRangeException();
            return data[0];
        } }

        public T Tail { get {
            if (IsEmpty())
                throw new IndexOutOfRangeException();
            return data[Size - 1];
        } }

        public ArrayQueue(int capacity) //Constructor del ArrayQueue
        {
            data = new T[capacity];
            minCapacity = capacity;
            Size = 0;
        }

        public bool IsEmpty() => Size == 0;
        public T DeQueue()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Empty Queue");
            }
            T poppedElement = data[0];
            T[] arrayTemp = new T[Size - 1];

            Array.Copy(data, 1, arrayTemp, 0, --Size);

            if (Size == minCapacity)
            {
                Array.Resize<T>(ref data, minCapacity);
            }

            Array.Copy(arrayTemp, 0, data, 0, Size);

            return poppedElement;
        }
        public string DeQueue(int numberOfTimes)
        {
            T[] poppedElements = new T[numberOfTimes];

            for (int i = 0; i < numberOfTimes; i++)
            {
                poppedElements[i] = DeQueue();
            }

            string data = string.Join<T>(", ", poppedElements);

            return data;
        }

        public void EnQueue(T element)
        {
            if (Size + 1 >= minCapacity)
            {
                Array.Resize<T>(ref data, Size + 3);
            }

            data[Size++] = element;
        }
        public void EnQueue(params T[] elements)
        {
            Array.ForEach<T>(elements, e => EnQueue(e));
        }
        public override string ToString()
        {
            string debug = $"[C:{data.Length} S:{Size} Empty:{IsEmpty()}]";

            debug += " { ";
            for (int i = 0; i < Size; ++i)
            {
                debug += $"{data[i]} ";
            }
            debug += "}";

            return debug;
        }
    }
}
