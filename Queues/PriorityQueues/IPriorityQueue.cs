using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    interface IPriorityQueue<T>
    {
        int Size { get; } //Retorna el n umero de elementos en el queue.
        T Head { get; } //Retorna el primer elemento del queue, sin removerlo.
        T Tail { get; } //Retorna el  ́ultimo elemento del queue, sin removerlo.
        Comparison<T> PriorityComparer { get; } //Retorna la referencia a la función lambda que establece el criterio de prioridad entre los elementos.
        void EnQueue(T element); //Agrega el elemento al final del queue.
        T DeQueue(); //Remueve y retorna el primer elemento del queue.
        T PriorityDequeue(); //Remueve y retorna el elemento con la prioridad más altaque se encuentre más próximo al frente.
        T PriorityPeek(); //Retorna el elemento con la prioridad más alta que se encuentre más próximo al frente.
        bool IsEmpty(); //Retorna un booleano indicando si el queue está vacío. true si tiene elementos o false si no tiene.
    }
}
