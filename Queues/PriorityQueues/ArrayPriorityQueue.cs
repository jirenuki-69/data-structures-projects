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
        private T[] data; //(item1, item2)
        private int minCapacity;
        public int Size { get; private set; }

        public T Head { get {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Empty Queue"); //priorityQueue.Head
            return data[0];
        } }

        public T Tail { get {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Empty Queue");
            return data[Size - 1];
        } }

        public T[] Data { get => data; }

        public Comparison<T> PriorityComparer { get; }

        public ArrayPriorityQueue(int capacity, Comparison<T> comparer) //Constructor del ArrayQueue
        {
            data = new T[capacity];
            minCapacity = capacity;
            PriorityComparer = comparer; //Le paso la prioridad definida por el usuario
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

        public void EnQueue(T element)
        {
            if (Size + 1 >= minCapacity)
            {
                Array.Resize<T>(ref data, Size + 1);
            }

            data[Size++] = element;
        }

        public T PriorityDequeue()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("Empty Queue");
            }

            int index = 0;
            T[] aux = new T[Size];

            Array.Copy(data, aux, Size); //Copio la cola al array auxiliar
            Array.Sort<T>(aux, PriorityComparer); //Ordeno según la prioridad dada en el constructor de la clase

            index = Array.IndexOf<T>(data, aux[0]);//Busco el indice de la primera coincidencia del elemento con mayor prioridad
            T poppedElement = data[index]; //Tomo el elemento a quitar de la cola de prioridad

            int[] remainingInQueue = GetRemainingInQueue(index); //Saco cuantos a la izquierda y derecha hay del elemento a sacar
            T[] leftQueue = new T[remainingInQueue[0]]; //Cuantos quedan a la izquieda
            T[] rightQueue = new T[remainingInQueue[1]]; //Cuantos quedan a la derecha

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

            T[] aux = new T[Size];
            Array.Copy(data, aux, Size);//Copio los elementos a mi array auxiliar
            Array.Sort(aux, PriorityComparer); //Ordeno los elementos de acuerdo a la prioridad dada en el constructor
            T element = aux[0];

            return element; //Retorno el elemento con mayor prioridad en la cola
        }

        private int[] GetRemainingInQueue(int index)
        {
            int remainingInLeft = 0;
            int remainingInRight = 0;

            for(int i = index; i > 0; i--) {
                remainingInLeft += 1;
            }

            for (int i = index; i < Size - 1; i++) {
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
                debug += $"{data[i]} ";
            }
            debug += "}";

            return debug;
        }
    }
}
