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
            ArrayQueue<int> myArrayQueue = new ArrayQueue<int>(6);

            myArrayQueue.EnQueue(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine(myArrayQueue);
            myArrayQueue.DeQueue();
            Console.WriteLine(myArrayQueue);
            myArrayQueue.DeQueue(3);
            Console.WriteLine(myArrayQueue);

            //myArrayQueue.DeQueue();
            //Console.WriteLine(myArrayQueue);
            //Console.WriteLine(myArrayQueue.Head);

            Console.ReadKey();
        }
    }
}
