using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class ArrayDeque<T> : IDeque<T>
    {
        private T[] data;
        private int minCapacity;
        public int Size {get; private set;}

        public T Front  {get; private set;}
        public T Back {get; private set;}


        public ArrayDeque(int capacity) //Constructor del ArrayQueue
        {
            data = new T[capacity];
            minCapacity = capacity;
            Size = 0;
        }
        public T PopBack()
        {
            if (!IsEmpty())
            {
                T element = data[Size - 1];

                Array.Clear(data, data.Length -1, 1);//Limpio el ultimo elemento

                T[] arrayTemp = new T[--Size];

                Array.Copy(data, 0, arrayTemp, 0, Size);//Nuevo queue temporal
                Array.Resize<T>(ref data, Size);//Nuevo tamaño de data
                Array.Copy(arrayTemp, data, Size); //Se hace un queue con el elemento removido

                if (data.Length != 0) {
                    Back = data[data.Length - 1];
                } else {
                    Back = default(T);
                }

                return element; //Retorno el elemento removido
            } else {
                throw new IndexOutOfRangeException("Empty Queue");
            }
        }
      
        public bool IsEmpty() => Size == 0;
        public T PopFront()
        {
            if (!IsEmpty())
            {
                T element = data[0];

                Array.Clear(data, 0, 1);//Limpio el primer elemento

                T[] arrayTemp = new T[--Size];

                Array.Copy(data, 1, arrayTemp, 0, Size);//Nuevo queue temporal

                if(Size + 1 >= minCapacity) {
                    Array.Resize<T>(ref data, Size + 1);//Nuevo tamaño de data
                } else {
                    Array.Resize<T>(ref data, minCapacity);//Nuevo tamaño de data
                }

                Array.Copy(arrayTemp, data, Size); //Se hace un queue con el elemento removido

                if (data.Length != 0) {
                    Front = data[0];
                } else {
                    Front = default(T);
                }

                return element; //Retorno el elemento removido
            }
            else
            {
                throw new IndexOutOfRangeException("Empty Queue");
            }
        }

        public void PushBack(T element)
        {
            if (Size == 0) {
                Front = element;
            }

            Back = element;

            if (Size + 1 >= minCapacity) {
                Array.Resize<T>(ref data, Size + 1); //Agrego un nuevo tamaño al arreglo
            }

            data[Size++] = element; //Agregar elemento al final del array
        }
        public void PushBack(params T[] elements)
        {
            Array.ForEach<T>(elements, e => PushBack(e));
        }

        public void PushFront(T element)
        {
            Front = element;

            if (Size == 0)
            {
                Back = element;
            }

            T[] arrayTemp = new T[++Size + 1];
            arrayTemp[0] = element;

            Array.Copy(data, 0, arrayTemp, 1, Size - 1);
            Array.Copy(arrayTemp, data, Size);

            if (Size + 1 >= minCapacity)
            {
                Array.Resize<T>(ref data, Size + 1); //Agrego un nuevo tamaño al arreglo
            }
            data[0] = element; //Agregar elemento al final del array
        }
        public void PushFront(params T[] elements)
        {
            Array.ForEach<T>(elements, e => PushFront(e));
            Front = elements.Last<T>();
            Back = Size == 0 ? Back = elements.First<T>() : data[Size - 1];
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
