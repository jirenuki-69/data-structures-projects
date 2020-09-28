using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    interface IQueue<T>
    {
        int Size { get; }
        T Head { get; }
        T Tail { get; }
        void EnQueue(T element);
        T DeQueue();
        bool IsEmpty();
    }
}
