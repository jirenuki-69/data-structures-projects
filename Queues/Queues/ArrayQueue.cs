using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class ArrayQueue<T> : IQueue<T>
    {
        private T[] data; //Arreglo que guarda los elementos de la cola
        private int minCapacity; //Esta variable me sirve para saber la capacidad minima del arreglo
        public int Size { get; private set; } //Cantidad de elementos en la cola

        public T Head { get {
            if (IsEmpty()) //Cuando quiero conseguir el valor de Head, hago una sentencia si el queue está vacío
                throw new IndexOutOfRangeException(); //De ser vacío, el programa arroja un error
            return data[0]; //En caso de que haya elementos, retorno la cabeza de la cola (primera posición)
        } }

        public T Tail { get {
            if (IsEmpty()) //Cuando quiero conseguir el valor de Head, hago una sentencia si el queue está vacío
                throw new IndexOutOfRangeException(); //De ser vacío, el programa arroja un error
            return data[Size - 1]; //En caso de que haya elementos, retorno el elemento que está al final de la cola
        } }

        public ArrayQueue(int capacity) //Constructor del ArrayQueue
        {
            data = new T[capacity]; //Determino el tamaño del arreglo
            minCapacity = capacity; //Determino la capacidad mínima
            Size = 0; //Comienzo sin elementos
        }

        public bool IsEmpty() => Size == 0; 
        public T DeQueue() //Quitar de la cola la cabeza de la cola
        {
            if (IsEmpty()) //Primero necesito saber si está vacío
            {
                throw new IndexOutOfRangeException("Empty Queue"); //Se arroja error si logra estar vacío
            }
            T poppedElement = data[0]; //Consigo el elemento que se va a retirar de la cola
            T[] arrayTemp = new T[Size - 1]; //Arreglo auxiliar con un tamaño de Size - 1 para guardar los elementos menos el que se va a quitar

            Array.Copy(data, 1, arrayTemp, 0, --Size); //Copio los datos a mi auxiliar

            if (Size == minCapacity)
            {
                Array.Resize<T>(ref data, minCapacity);
            }

            Array.Copy(arrayTemp, 0, data, 0, Size); //Copio a mi data todos los elementos excepto el que se quitó

            return poppedElement; //retorno el elemento
        }
        public string DeQueue(int numberOfTimes) //Esto es para quitar elementos según un entero para contar las veces que se repita
        {
            T[] poppedElements = new T[numberOfTimes]; //Arreglo que contiene los elementos que se vana quitar

            for (int i = 0; i < numberOfTimes; i++)
            {
                poppedElements[i] = DeQueue(); //Asigno al arreglo lo que me devuelva el dequeue
            }

            string data = string.Join<T>(", ", poppedElements); //string para imprimir todos los elementos quitados

            return data; //retorno el string
        }

        public void EnQueue(T element) //Poner en la cola nuevos elementos
        {
            if (Size + 1 >= minCapacity) //Verifico si con el proximo valor de Size, excede o es igual a la capacidad mínima
            {
                Array.Resize<T>(ref data, Size + 3); //Le doy más tamaño al arreglo para que sea flexible
            }

            data[Size++] = element; //En la posicion size pongo el elemento y luego sumo su valor
        }
        public void EnQueue(params T[] elements) //Aquí puedo insertar varios elementos para ponerlos en cola
        {
            Array.ForEach<T>(elements, e => EnQueue(e)); //Foreach para poner cada elemento a un EnQueue
        }
        public override string ToString() //Esto sirve para que cada vez que se ejecute un método ToString a un arrayQueue, imprima de cierta manera
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
