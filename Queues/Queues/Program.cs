using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------QUEUE-------");

            ArrayQueue<int> myArrayQueue = new ArrayQueue<int>(6);

            myArrayQueue.EnQueue(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine(myArrayQueue);
            Console.WriteLine($"Head: {myArrayQueue.Head}");
            Console.WriteLine($"Tail: {myArrayQueue.Tail}");
            myArrayQueue.EnQueue(9);
            Console.WriteLine(myArrayQueue);
            Console.WriteLine($"Head: {myArrayQueue.Head}");
            Console.WriteLine($"Tail: {myArrayQueue.Tail}");
            myArrayQueue.DeQueue();
            Console.WriteLine(myArrayQueue);
            Console.WriteLine($"Head: {myArrayQueue.Head}");
            Console.WriteLine($"Tail: {myArrayQueue.Tail}");
            myArrayQueue.DeQueue(3);
            Console.WriteLine(myArrayQueue);
            Console.WriteLine($"Head: {myArrayQueue.Head}");
            Console.WriteLine($"Tail: {myArrayQueue.Tail}");

            Console.ReadKey();
        }
    }
}
