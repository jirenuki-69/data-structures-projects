using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    interface IDeque<T>
    {
        int Size { get; }
        T Front { get; }
        T Back { get; }
        void PushBack(T element);
        void PushFront(T element);
        T PopBack();
        T PopFront();
        bool IsEmpty();
    }
}
