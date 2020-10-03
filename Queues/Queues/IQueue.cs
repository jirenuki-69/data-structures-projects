using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    interface IQueue<T>
    {
        int Size { get; } //Retorna el n umero de elementos en el queue.
        T Head { get; } //Retorna el primer elemento del queue, sin removerlo.
        T Tail { get; } //Retorna el  ́ultimo elemento del queue, sin removerlo.
        void EnQueue(T element); //Agrega el elemento al final del queue.
        T DeQueue(); //Remueve y retorna el primer elemento del queue.
        bool IsEmpty(); //Retorna un booleano indicando si el queue está vacío. true si tiene elementos o false si no tiene.
    }
}
