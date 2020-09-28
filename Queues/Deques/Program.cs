using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deques
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------DEQUE-------");

            ArrayDeque<string> deque = new ArrayDeque<string>(6);

            deque.PushFront("Miguel");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            deque.PushFront("Russell");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            Console.WriteLine($"PopFront: {deque.PopFront()}");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            deque.PushBack("Abraham");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            deque.PushBack("Russell");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            deque.PushBack("Puki");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            deque.PushBack("Willian", "Paco", "Jime");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            Console.WriteLine($"PopBack: {deque.PopBack()}");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            Console.WriteLine($"2 PopFronts: {deque.PopFront(2)}");
            Console.WriteLine(deque);

            Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            //Console.WriteLine($"2 PopBacks: {deque.PopBack(2)}");
            //Console.WriteLine(deque);

            //Console.WriteLine($"Front: {deque.Front}\nBack: {deque.Back}");

            Console.ReadKey();
        }
    }
}
