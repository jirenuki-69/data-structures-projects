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
        private T[] data; //Arreglo que guarda los elementos de la cola
        private int minCapacity; //Esta variable me sirve para saber la capacidad minima del arreglo
        public int Size { get; private set; } //Cantidad de elementos en la cola

        public T Head { get {
            if (IsEmpty()) //Cuando quiero conseguir el valor de Head, hago una sentencia si el queue está vacío
                throw new IndexOutOfRangeException("Empty Queue");  //De ser vacío, el programa arroja un error
            return data[0]; //En caso de que haya elementos, retorno la cabeza de la cola (primera posición)
        } }

        public T Tail { get {
            if (IsEmpty()) //Cuando quiero conseguir el valor de Head, hago una sentencia si el queue está vacío
                throw new IndexOutOfRangeException("Empty Queue"); //De ser vacío, el programa arroja un error
            return data[Size - 1]; //En caso de que haya elementos, retorno el elemento que está al final de la cola
        } }

        public T[] Data { get => data; } //hago accesible el valor de data para los interesados en saber el queue

        public Comparison<T> PriorityComparer { get; } //Este guarda el comparador por la referencia lambda asignada al constructor de la clase

        public ArrayPriorityQueue(int capacity, Comparison<T> comparer) //Constructor del ArrayPriorityQueue
        {
            data = new T[capacity]; //Determino el tamaño del arreglo
            minCapacity = capacity; //Determino la capacidad mínima
            PriorityComparer = comparer; //Le paso la prioridad definida por el usuario
            Size = 0; //Comienzo sin elementos
        }

        public bool IsEmpty() => Size == 0; //Método para saber si la cola está vacía

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

        public void EnQueue(T element) //Poner en la cola nuevos elementos
        {
            if (Size + 1 >= minCapacity) //Verifico si con el proximo valor de Size, excede o es igual a la capacidad mínima
            {
                Array.Resize<T>(ref data, Size + 1); //Le doy más tamaño al arreglo para que sea flexible
            }

            data[Size++] = element; //En la posicion size pongo el elemento y luego sumo su valor
        }

        public T PriorityDequeue() //Remuevo y retorno de la cola el elemento con más prioridad y que esté más próximo al frente
        {
            if (IsEmpty()) //Está vació el queue?
            {
                throw new IndexOutOfRangeException("Empty Queue"); //Lanzo un error de ser así
            }

            int index = 0; //Aquí va el índice en donde se encuentra el elemento a quitar dentro de data
            T[] aux = new T[Size]; //array auxiliar para hacer copias

            Array.Copy(data, aux, Size); //Copio la cola al array auxiliar
            Array.Sort<T>(aux, PriorityComparer); //Ordeno según la prioridad dada en el constructor de la clase

            index = Array.IndexOf<T>(data, aux[0]); //Busco el indice de la primera coincidencia del elemento con mayor prioridad
            T poppedElement = data[index]; //Tomo el elemento a quitar de la cola de prioridad

            int[] remainingInQueue = GetRemainingInQueue(index); //Saco cuantos a la izquierda y derecha hay del elemento a sacar
            T[] leftQueue = new T[remainingInQueue[0]]; //Cuantos quedan a la izquieda
            T[] rightQueue = new T[remainingInQueue[1]]; //Cuantos quedan a la derecha

            Array.Copy(data, 0, leftQueue, 0, leftQueue.Length); //Copiar los elementos a la izquierda del eliminado
            Array.Copy(data, leftQueue.Length + 1, rightQueue, 0, rightQueue.Length); //Copiar los elementos a la derecha del eliminado

            Array.Copy(leftQueue, 0, data, 0, leftQueue.Length); //Pasar los elementos a data
            Array.Copy(rightQueue, 0, data, leftQueue.Length, rightQueue.Length); //Pasar los elementos a data

            Size--; //decremento el valor de Size a 1
            return poppedElement; //retorno el elemento removido de la cola que es el de mayor prioridad y más próximo al frente
        }

        public T PriorityPeek() //Retorno de la cola el elemento con más prioridad y que esté más próximo al frente
        {
            if (IsEmpty()) //Está vació el queue?
            {
                throw new IndexOutOfRangeException("Empty Queue"); //Lanzo un error de ser así
            }

            T[] aux = new T[Size];
            Array.Copy(data, aux, Size);//Copio los elementos a mi array auxiliar
            Array.Sort(aux, PriorityComparer); //Ordeno los elementos de acuerdo a la prioridad dada en el constructor
            T element = aux[0]; //El primer elemento es el de mayor prioridad

            return element; //Retorno el elemento con mayor prioridad en la cola y más próximo al frente
        }

        private int[] GetRemainingInQueue(int index) //Aquí recibo cuantos elementos hay a la izquierda y derecha del elemento a remover
        {
            int remainingInLeft = 0; //Aqui guardare la cantidad a la izquierda
            int remainingInRight = 0; //Aqui guardare la cantidad a la derecha

            for (int i = index; i > 0; i--) {
                remainingInLeft += 1;
            }

            for (int i = index; i < Size - 1; i++) {
                remainingInRight += 1;
            }

            int[] remainingInQueue = new int[2] { remainingInLeft, remainingInRight }; //Este es un arreglo en donde guardo la cantidadde { izquierda, derecha } 

            return remainingInQueue; //retorno el arreglo de enteros
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
