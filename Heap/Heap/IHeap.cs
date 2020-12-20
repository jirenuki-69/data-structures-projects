using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    interface IHeap<T>
    {
        int Size { get; }
        T Min { get; }
        T RemoveMin { get; }
        bool IsEmpty();
        void Insert(T element);
    }
}
