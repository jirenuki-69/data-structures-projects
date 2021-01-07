using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph<T> : IGraph<T>
    {
        public int Size { get; private set; }

        public Tuple<bool, int>[,] matriz;

        int Capacity { get; set; }

        public Graph(int minCapacity)
        {
            Size = 0;
            Capacity = minCapacity;
            matriz = new Tuple<bool, int>[Capacity, Capacity];
        }

        //Agrego un nuevo nodo al grafo
        public Node<T> AgregarNodo()
        {
            if (Size + 1 >= Capacity)
            {
                matriz = ResizeArray();
                Capacity *= 2;
            }

            return new Node<T>(Size++, this);
        }

        //Agrego una arista que conecte dos nodos pertenecientes al grafo
        public void AgregarArista(Node<T> firstNode, Node<T> secondNode)
        {
            if (firstNode == secondNode)
                throw new Exception("No se puede agregar una arista al mismo nodo");

            else if (firstNode.Graph != this || secondNode.Graph != this)
                throw new Exception("Alguno de estos nodos no pertenecen al grafo");

            matriz[firstNode.Index, secondNode.Index] = Tuple.Create(true, 1);
            matriz[secondNode.Index, firstNode.Index] = Tuple.Create(true, 1);
        }

        //Agrego una arista que conecte dos nodos pertenecientes al grafo y se le asigna un precio al tomar esa arista
        public void AgregarArista(Node<T> firstNode, Node<T> secondNode, int precio)
        {
            if (firstNode.Graph != this || secondNode.Graph != this)
                throw new Exception("Alguno de estos nodos no pertenecen al grafo");

            matriz[firstNode.Index, secondNode.Index] = Tuple.Create(true, precio);
            matriz[secondNode.Index, firstNode.Index] = Tuple.Create(true, precio);
        }

        Tuple<bool, int>[,] ResizeArray()
        {
            Tuple<bool, int>[,] newArray = new Tuple<bool, int>[Capacity * 2, Capacity * 2];
            int minRows = Math.Min(Capacity * 2, matriz.GetLength(0));
            int minCols = Math.Min(Capacity * 2, matriz.GetLength(1));

            for (int i = 0; i < minRows; ++i)
            {
                for (int j = 0; j < minCols; ++j)
                {
                    newArray[i, j] = matriz[i, j];
                }
            }

            return newArray;
        }

        public void MostrarMatriz()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 0; i < Size; ++i)
                Console.Write($"\t{i}");

            Console.WriteLine();

            for (int i = 0; i < Size; ++i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(i);

                for (int j = 0; j < Size; ++j)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    if (matriz[i, j] != null)
                        Console.Write($"\t{matriz[i, j].Item2}");
                    else
                        Console.Write($"\tnull");
                }

                Console.WriteLine();
            }
        }
    }
}
