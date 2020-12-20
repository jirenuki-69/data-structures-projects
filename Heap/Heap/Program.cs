using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap<int> heap = new Heap<int>();

            heap.Insert(10);
            heap.Insert(3);
            heap.Insert(56);
            heap.Insert(9);
            heap.Insert(1);

            Console.WriteLine(heap);

            Console.WriteLine($"RemoveMin: {heap.RemoveMin}");

            Console.WriteLine(heap);

            Console.WriteLine();

            Console.WriteLine("***HEAPIFY***");

            List<int> list = new List<int>() { 14, 5, 8, 25, 9, 11, 17, 16, 15, 4, 12, 6, 7, 23, 20 };

            Heap<int> newHeap = Heap<int>.Heapify(list);

            Console.WriteLine(newHeap);

            Console.WriteLine();

            Console.WriteLine("***HEAPSORT***");

            Heap<int>.HeapSort(list);

            Console.Write("[ ");

            list.ForEach(element => Console.Write($"{element} "));

            Console.WriteLine("]");

            Console.ReadKey();
        }
    }
}
