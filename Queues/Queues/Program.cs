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
            ArrayQueue<string> queue = new ArrayQueue<string>(2);

            queue.EnQueue("Miguel");
            Console.WriteLine(queue);

            Console.WriteLine($"Head: {queue.Head}\nTail: {queue.Tail}");

            queue.EnQueue("Roger");
            Console.WriteLine(queue);

            Console.WriteLine($"Head: {queue.Head}\nTail: {queue.Tail}");

            queue.EnQueue("Sergio");
            Console.WriteLine(queue);

            Console.WriteLine($"Head: {queue.Head}\nTail: {queue.Tail}");

            queue.DeQueue();
            Console.WriteLine(queue);

            Console.WriteLine($"Head: {queue.Head}\nTail: {queue.Tail}");

            queue.DeQueue();
            Console.WriteLine(queue);

            Console.WriteLine($"Head: {queue.Head}\nTail: {queue.Tail}");

            queue.DeQueue();
            Console.WriteLine(queue);

            queue.EnQueue("Miguel", "Roger", "Tostado");
            Console.WriteLine(queue);

            Console.WriteLine($"Head: {queue.Head}\nTail: {queue.Tail}");

            queue.EnQueue("Luis", "Sergio");
            Console.WriteLine(queue);

            Console.WriteLine($"Head: {queue.Head}\nTail: {queue.Tail}");

            Console.WriteLine($"Dequeing elements: {queue.DeQueue(5)}");
            Console.WriteLine(queue);

            Console.ReadKey();

        }
    }
}
