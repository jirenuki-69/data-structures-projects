using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class ArrayQueue<T> : IQueue<T>
    {
        private T[] data;
        private int minCapacity;
        public int Size { get; private set; }

        public T Head { get; private set; }

        public T Tail { get; private set; }

        public ArrayQueue(int capacity) //Constructor del ArrayQueue
        {
            data = new T[capacity];
            minCapacity = capacity;
            Size = 0;
        }

        public T DeQueue()
        {
            if (!IsEmpty())
            {
                T element = data[0];

                Array.Clear(data, 0, 1);//Limpio el primer elemento

                T[] arrayTemp = new T[--Size];

                Array.Copy(data, 1, arrayTemp, 0, Size);//Nuevo queue temporal
                Array.Resize<T>(ref data, Size + 1);//Nuevo tamaño de data
                Array.Copy(arrayTemp, data, Size); //Se hace un queue con el elemento removido

                if (data.Length != 0) {
                    Head = data[0];          
                } else {
                    Head = default(T);
                }

                return element; //Retorno el elemento removido
            } else {
                throw new IndexOutOfRangeException("Empty Queue");
            }
        }

        public void DeQueue(int numberOfTimes)
        {
            for(int i = 0; i < numberOfTimes; i++)
            {
                DeQueue();
            }
        }

        public void EnQueue(T element)
        {
            if (Size == 0)
            {
                Head = element;
            }

            Tail = element;

            if (Size + 1 >= minCapacity)
            {
                Array.Resize<T>(ref data, Size + 1); //Agrego un nuevo tamaño al arreglo
            }
            data[Size++] = element; //Agregar elemento al final del array
        }
        public void EnQueue(params T[] elements)
        {
            if (Size == 0)
            {
                Head = elements[0];
            }
            Array.ForEach<T>( elements, e => EnQueue(e) );
        }

        public bool IsEmpty() => Size == 0;

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
