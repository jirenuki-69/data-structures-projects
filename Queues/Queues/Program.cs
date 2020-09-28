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
            ArrayDeque<int> myArrayDeque = new ArrayDeque<int>(6);

            myArrayQueue.EnQueue(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine(myArrayQueue);
            myArrayQueue.DeQueue();
            Console.WriteLine(myArrayQueue);
            myArrayQueue.DeQueue(3);
            Console.WriteLine(myArrayQueue);

            myArrayDeque.PushBack(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine(myArrayDeque);
            Console.WriteLine(myArrayDeque.Back);
            Console.WriteLine(myArrayDeque.Front);
            myArrayDeque.PopFront();
            Console.WriteLine(myArrayDeque);
            Console.WriteLine(myArrayDeque.Back);
            Console.WriteLine(myArrayDeque.Front);
            myArrayDeque.PushFront(-4, -3, -2, - 1);
            Console.WriteLine(myArrayDeque);
            Console.WriteLine(myArrayDeque.Back);
            Console.WriteLine(myArrayDeque.Front);
            Console.WriteLine(myArrayDeque);
            myArrayDeque.PopBack();
            Console.WriteLine(myArrayDeque);
            Console.WriteLine(myArrayDeque.Back);
            Console.WriteLine(myArrayDeque.Front);
            //myArrayQueue.DeQueue();
            //Console.WriteLine(myArrayQueue);
            //Console.WriteLine(myArrayQueue.Head);

            Console.ReadKey();
        }
    }
}
