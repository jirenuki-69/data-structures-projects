using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.AddRoot(0);

            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            //Root izquierdo
            Node<int> uno = tree.AddLeftChild(tree.RootNode, 1);
            Node<int> dos = tree.AddLeftChild(uno, 2);
            Node<int> cuatro = tree.AddLeftChild(dos, 4);
            Node<int> seis = tree.AddLeftChild(cuatro, 6);
            Node<int> tres = tree.AddRightChild(uno, 3);
            Node<int> cinco = tree.AddRightChild(dos, 5);
            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            //Root Derecho
            Node<int> siete = tree.AddRightChild(tree.RootNode, 7);
            Node<int> ocho = tree.AddRightChild(siete, 8);
            Node<int> nueve = tree.AddLeftChild(ocho, 9);
            Node<int> diez = tree.AddRightChild(ocho, 10);
            Node<int> once = tree.AddRightChild(nueve, 11);
            
            tree.ForEach(element => Console.WriteLine(element), 3); //PostOrder 

            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            //tree.DeleteNode(seis, false);
            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            //tree.DeleteNode(once, false);
            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            foreach (int element in tree)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
