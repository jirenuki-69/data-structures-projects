using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayPriorityQueue<string> priorityQueue = new ArrayPriorityQueue<string>(5);

            priorityQueue.EnQueue("Russell", 10);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            priorityQueue.EnQueue("Abraham", 8);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            priorityQueue.EnQueue("Puki", 13);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            priorityQueue.EnQueue("Miguel", 9);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            Console.WriteLine($"Priority Peek: {priorityQueue.PriorityPeek()}");
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            priorityQueue.EnQueue("Willy", 11);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            priorityQueue.EnQueue("Paco", 13);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            int size = priorityQueue.Size;

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Priority Dequeue: {priorityQueue.PriorityDequeue()}");
                Console.WriteLine(priorityQueue);
            }

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}");

            Console.ReadKey();
        }
    }
}
