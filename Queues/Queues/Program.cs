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
            ArrayDeque<int> myArrayDeque = new ArrayDeque<int>(6);

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

            Console.WriteLine("-------DEQUE-------");

            myArrayDeque.PushBack(1, 2, 3, 4);
            Console.WriteLine(myArrayDeque);
            Console.WriteLine($"Back: {myArrayDeque.Back}");
            Console.WriteLine($"Front: {myArrayDeque.Front}");
            myArrayDeque.PushFront(-4, -3, -2, - 1);
            Console.WriteLine(myArrayDeque);
            Console.WriteLine($"Back: {myArrayDeque.Back}");
            Console.WriteLine($"Front: {myArrayDeque.Front}");
            Console.WriteLine($"PopBack: {myArrayDeque.PopBack()}");
            Console.WriteLine(myArrayDeque);
            Console.WriteLine($"PopFront: {myArrayDeque.PopFront()}");
            Console.WriteLine(myArrayDeque);
            Console.WriteLine($"Back: {myArrayDeque.Back}");
            Console.WriteLine($"Front: {myArrayDeque.Front}");
            myArrayDeque.PushFront(9);
            myArrayDeque.PushBack(13); 
            Console.WriteLine(myArrayDeque);
            Console.WriteLine($"Front: {myArrayDeque.Front}");
            Console.WriteLine($"Back: {myArrayDeque.Back}");
            myArrayDeque.PushBack(1, 2, 3, 4, 5);
            Console.WriteLine(myArrayDeque);
            Console.WriteLine($"Front: {myArrayDeque.Front}");
            Console.WriteLine($"Back: {myArrayDeque.Back}");
            int stop = myArrayDeque.Size;

            //for (int i = 0; i < stop; i++)
            //{
            //    Console.WriteLine($"PopFront: {myArrayDeque.PopFront()}");
            //    Console.WriteLine(myArrayDeque);
            //    Console.WriteLine($"Back: {myArrayDeque.Back}");
            //    Console.WriteLine($"Front: {myArrayDeque.Front}");
            //}

            for (int i = 0; i < stop; i++)
            {
                Console.WriteLine($"PopBack: {myArrayDeque.PopBack()}");
                Console.WriteLine(myArrayDeque);
                Console.WriteLine($"Back: {myArrayDeque.Back}");
                Console.WriteLine($"Front: {myArrayDeque.Front}");
            }

            Console.ReadKey();
        }
    }
}
