using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    interface IPriorityQueue<T>
    {
        int Size { get; }
        T Head { get; }
        T Tail { get; }
        Comparison<T> PriorityComparer { get; }
        void EnQueue(T element);
        T DeQueue();
        T PriorityDequeue();
        T PriorityPeek();
        bool IsEmpty();
    }
}
