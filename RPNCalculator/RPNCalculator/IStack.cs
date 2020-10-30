using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    interface IStack<T>
    {
        int Size { get; }
        bool IsEmpty();
        void Push(T element);
        void Push(params T[] elements);
        T Pop();
        T Peek();
    }
}
