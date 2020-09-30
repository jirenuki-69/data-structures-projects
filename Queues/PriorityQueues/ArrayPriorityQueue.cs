using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    class ArrayPriorityQueue<T> : IPriorityQueue<T>
    {
        private Tuple<T, int>[] data; //(item1, item2)
        private int minCapacity;
        public int Size { get; private set; }

        public T Head { get {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Empty Queue"); //priorityQueue.Head
            return data[0].Item1;
        } }

        public T Tail { get {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Empty Queue");
            return data[Size - 1].Item1;
        } }

        public ArrayPriorityQueue(int capacity) //Constructor del ArrayQueue
        {
            data = new Tuple<T, int>[capacity];
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
            T poppedElement = data[0].Item1;
            T[] arrayTemp = new T[Size - 1];

            Array.Copy(data, 1, arrayTemp, 0, --Size);

            if (Size == minCapacity)
            {
                Array.Resize<Tuple<T, int>>(ref data, minCapacity);
            }

            Array.Copy(arrayTemp, 0, data, 0, Size);

            return poppedElement;
        }

        public void EnQueue(T element, int priority)
        {
            if (Size + 1 >= minCapacity)
            {
                Array.Resize<Tuple<T, int>>(ref data, Size + 3);
            }

            data[Size++] = Tuple.Create(element, priority);
        }

        public T PriorityDequeue()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Empty Queue");
            }

            int maxPriority = data[0].Item2;
            int index = 0;

            for (int i = 0; i < Size; i++)
            {

                if (data[i].Item2 > maxPriority)
                {
                    maxPriority = data[i].Item2;
                    index = i;
                }
            }

            T poppedElement = data[index].Item1;

            int[] remainingInQueue = GetRemainingInQueue(index);
            Tuple<T, int>[] leftQueue = new Tuple<T, int>[remainingInQueue[0]];
            Tuple<T, int>[] rightQueue = new Tuple<T, int>[remainingInQueue[1]];

            Array.Copy(data, 0, leftQueue, 0, leftQueue.Length); //Copiar los elementos a la izquierda del eliminado
            Array.Copy(data, leftQueue.Length + 1, rightQueue, 0, rightQueue.Length); //Copiar los elementos a la derecha del eliminado

            Array.Copy(leftQueue, 0, data, 0, leftQueue.Length); //Pasar los elementos a data
            Array.Copy(rightQueue, 0, data, leftQueue.Length, rightQueue.Length); //Pasar los elementos a data

            Size--;
            return poppedElement;
        }

        public T PriorityPeek()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Empty Queue");
            }

            int maxPriority = data[0].Item2;
            int index = 0;

            for (int i = 0; i < Size; i++) {

                if(data[i].Item2 > maxPriority) {
                    maxPriority = data[i].Item2;
                    index = i;
                }

            }

            return data[index].Item1;
        }

        private int[] GetRemainingInQueue(int index)
        {
            int remainingInLeft = 0;
            int remainingInRight = 0;

            for(int i = index; i > 0; i--) {
                remainingInLeft += 1;
            }

            for (int i = index; i < Size; i++) {
                remainingInRight += 1;
            }

            int[] remainingInQueue = new int[2] { remainingInLeft, remainingInRight }; //[3, 10]

            return remainingInQueue;
        }

        public override string ToString()
        {
            string debug = $"[C:{data.Length} S:{Size} Empty:{IsEmpty()}]";

            debug += " { ";
            for (int i = 0; i < Size; ++i)
            {
                debug += $"{data[i].Item1} ";
            }
            debug += "}";

            return debug;
        }
    }
}
