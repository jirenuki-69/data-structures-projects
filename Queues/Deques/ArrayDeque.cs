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
        private T[] data; //Arreglo que guarda los elementos de la cola
        private int minCapacity; //Esta variable me sirve para saber la capacidad minima del arreglo
        public int Size { get; private set; } //Cantidad de elementos en la cola

        public T Front { get {
            if (IsEmpty()) //Cuando quiero conseguir el valor de Head, hago una sentencia si el queue está vacío
                throw new IndexOutOfRangeException(); //De ser vacío, el programa arroja un error
            return data[0]; //En caso de que haya elementos, retorno la cabeza de la cola (primera posición)
        } }

        public T Back { get {
            if (IsEmpty()) //Cuando quiero conseguir el valor de Head, hago una sentencia si el queue está vacío
                throw new IndexOutOfRangeException(); //De ser vacío, el programa arroja un error
            return data[Size - 1]; //En caso de que haya elementos, retorno el elemento que está al final de la cola
        } }

        public ArrayDeque(int capacity) //Constructor del Deque
        {
            data = new T[capacity]; //Determino el tamaño del arreglo
            minCapacity = capacity; //Determino la capacidad mínima
            Size = 0; //Comienzo sin elementos
        }

        public bool IsEmpty() => Size == 0; //Método para saber si la cola está vacía

        public T PopBack() //Método para retirar un elemento que está al final de la cola
        {
            if (IsEmpty()) //Está vacío el deque?
            {
                throw new InvalidOperationException("Empty Queue"); //Se arroja error si logra estar vacío
            }

            T poppedElement = data[Size - 1]; //Consigo el elemento que se va a retirar de la cola
            T[] arrayTemp = new T[Size - 1]; //Arreglo auxiliar con un tamaño de Size - 1 para guardar los elementos menos el que se va a quitar

            Array.Copy(data, 0, arrayTemp, 0, --Size); //Copio los datos a mi auxiliar y decremento el valor de Size a 1
            Array.Copy(arrayTemp, data, Size); //Copio a mi data todos los elementos excepto el que se quitó

            return poppedElement; //retorno el elemento
        }

        public string PopBack(int numberOfTimes) //Retirar varios elementos de la parte de atrás de la cola
        {
            T[] poppedElements = new T[numberOfTimes]; //Array para guardar los elementos a quitar

            for (int i = 0; i < numberOfTimes; i++)
            {
                poppedElements[i] = PopBack(); //Le asigno el valor que retorne el PopBack
            }

            string data = string.Join(", ", poppedElements); //String para imprimir todos los elementos quitados al final de la cola

            return data; //retorno el String
        }

        public T PopFront() //Quito el elemento que está en la cabeza de la cola
        {
            if (IsEmpty()) //Está vacío el deque?
            {
                throw new InvalidOperationException("Empty Queue"); //Si está vacío lanzo el error
            }

            if (((Size - 1) <= data.Length / 2) &&
                ((data.Length / 2) >= minCapacity)) //Si está condición se cumple, necesito cambiar el tamaño del arreglo
            {
                Array.Resize<T>(ref data, data.Length / 2); //Lo disminuyo a la mitad
            }

            T poppedElement = data[0]; //Agarro la cabeza para quitarlo
            T[] arrayTemp = new T[Size - 1]; //Arreglo auxiliar con un tamaño de Size - 1 para guardar los elementos menos el que se va a quitar

            Array.Copy(data, 1, arrayTemp, 0, --Size); //Copio los datos a mi auxiliar
            Array.Copy(arrayTemp, data, Size); //Copio a mi data todos los elementos excepto el que se quitó

            return poppedElement; //retorno el elemento que se quitó
        }

        public string PopFront(int numberOfTimes) //retirar varios elementos de la cabeza
        {
            T[] poppedElements = new T[numberOfTimes]; //Array para guardar los elementos a quitar

            for (int i = 0; i < numberOfTimes; i++)
            {
                poppedElements[i] = PopFront(); //Le asigno el valor que retorne el PopBack
            }

            string data = string.Join(", ", poppedElements); //String para imprimir todos los elementos quitados al final de la cola

            return data; //retorno el String
        }

        public void PushBack(T element) //Poner un elemento al final de la cola
        {

            if (Size == data.Length) //verifico si la cantidad de elementos es igual al tamaño del arreglo
            {
                Array.Resize<T>(ref data, data.Length * 2); //El tamaño nuevo será el doble
            }

            data[Size++] = element; //En la posicion size pongo el elemento y luego sumo su valor
        }

        public void PushBack(params T[] elements) //Aquí puedo insertar varios elementos para ponerlos al final de la cola
        {
            Array.ForEach(elements, e => PushBack(e)); //Foreach para poner cada elemento a un PushBack
        }

        public void PushFront(T element) //Poner un elemento al principio de la cola
        {
            if (IsEmpty()) //Si el arreglo está vacío entonces solo pongo el elemento y termino
                data[Size++] = element;

            else //Si no está vacío...
            {
                T[] arrayTemp = new T[Size + 1]; //array auxiliar con un tamaño más

                Array.Copy(data, 0, arrayTemp, 1, Size); //copio los elementos de data a mi auxiliar partiendo desde el indice 1
                Array.Copy(arrayTemp, data, ++Size); //paso los de auxiliar a mi data y aumento el valor de Size a 1

                data[0] = element; //En la cabeza de la cola pongo el nuevo elemento
            }
        }
        public override string ToString() //Esto sirve para que cada vez que se ejecute un método ToString a un arrayQueue, imprima de cierta manera
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
