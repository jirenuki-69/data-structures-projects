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
            Tree<int> TreeSort(Tree<int> data)
            {
                if (data.IsEmpty())
                    return data;

                //Agarro los elementos del arbol y los pongo en las lista
                List<int> dataList = new List<int>();
                data.ForEach(e => dataList.Add(e), 2);

                Tree<int> newTree = new Tree<int>();
                //El root del arbol va a ser el primer elemento de la lista
                newTree.AddRoot(dataList[0]);

                PutChildrenAlgorithm(newTree, dataList);

                //Sustituyo el arbol por el nuevo que se creó
                return newTree;
            }

            void PutChildrenAlgorithm(Tree<int> newTree, List<int> data)
            {
                for (int i = 1; i < data.Count; ++i)
                {
                    PutData(newTree, newTree.RootNode, data[i]);
                }
            }

            void PutData(Tree<int> newTree, Node<int> currentNode, int data)
            {
                if (currentNode == null)
                    return;

                if (currentNode.LeftNode == null && data < currentNode.Data)
                    newTree.AddLeftChild(currentNode, data);

                else if (currentNode.RightNode == null && data >= currentNode.Data)
                    newTree.AddRightChild(currentNode, data);

                else if (currentNode.LeftNode != null && data < currentNode.Data)
                    PutData(newTree, currentNode.LeftNode, data);

                else if (currentNode.RightNode != null && data >= currentNode.Data)
                    PutData(newTree, currentNode.RightNode, data);
            }

            Tree<int> tree = new Tree<int>();

            List<int> list = new List<int>() { 1, 2, 3 };

            list.Sort();

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
            //Node<int> doce = tree.AddRightChild(once, 12);

            Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            Console.WriteLine("***FUNCIÓN FOREACH***");

            Console.Write("PreOrder: ");
            tree.ForEach(e => Console.Write($"{e} "), 1);
            Console.WriteLine();

            Console.Write("InOrder: ");
            tree.ForEach(e => Console.Write($"{e} "), 2);
            Console.WriteLine();

            Console.Write("PostOrder: ");
            tree.ForEach(e => Console.Write($"{e} "), 3);
            Console.WriteLine();

            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            //tree.DeleteNode(tree.RootNode, false);
            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            //tree.DeleteNode(uno, false);

            //tree.DeleteNode(once, false);
            //Console.WriteLine($"Size: {tree.Size}, Height {tree.Height}");

            Console.WriteLine("***CICLO FOREACH***");

            foreach (int element in tree)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("***TREE SORT***");

            int[] array = new int[] { 5, 4, 7, 2, 11, 14, 6 };

            Console.Write("Unsorted: ");
            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }

            tree.TreeSort(array);

            Console.WriteLine("");
            Console.Write("Sorted: ");
            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();

            tree = TreeSort(tree);

            Console.Write("InOrder: ");
            tree.ForEach(e => Console.Write($"{e} "), 2);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
