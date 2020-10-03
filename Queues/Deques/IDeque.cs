using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deques
{
    interface IDeque<T>
    {
        int Size { get; } //Retorna el número de elementos en el queue.
        T Front { get; } //Retorna el primer elemento del deque, sin removerlo.
        T Back { get; } //Retorna el ́ultimo elemento del deque, sin removerlo.
        void PushBack(T element); //Inserta un nuevo elemento al final del deque.
        void PushFront(T element); //Inserta un nuevo elemento al inicio del deque.
        T PopBack(); //Remueve y retorna el ́ultimo elemento del deque.
        T PopFront(); //Remueve y retorna el primer elemento del deque.
        bool IsEmpty(); //Retorna un booleano indicando si el deque está vacío.
    }
}
