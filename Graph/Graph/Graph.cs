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

        Tuple<Node<T>, int>[,] matriz;

        int Capacity { get; set; }
        public Tuple<Node<T>, int>[,] Matriz { get => matriz; set => matriz = value; }

        public Graph(int minCapacity)
        {
            Size = 0;
            Capacity = minCapacity;
            matriz = new Tuple<Node<T>, int>[Capacity, Capacity];
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

            matriz[firstNode.Index, secondNode.Index] = Tuple.Create(secondNode, 1);
        }

        //Agrego una arista que conecte dos nodos pertenecientes al grafo y se le asigna un precio al tomar esa arista
        public void AgregarArista(Node<T> firstNode, Node<T> secondNode, int precio)
        {
            if (firstNode == secondNode)
                throw new Exception("No se puede agregar una arista al mismo nodo");

            else if (firstNode.Graph != this || secondNode.Graph != this)
                throw new Exception("Alguno de estos nodos no pertenecen al grafo");

            matriz[firstNode.Index, secondNode.Index] = Tuple.Create(secondNode, precio);
        }

        //Algoritmo del camino más corto
        public void ShortestPath(Node<T> nodoInicio, Node<T> nodoFinal)
        {
            //Verifico si son nulos
            if (nodoInicio == null || nodoFinal == null)
                throw new Exception("nodos nulos");
            //Verifico si los dos nodos son del grafo
            else if (nodoInicio.Graph != this || nodoFinal.Graph != this)
                throw new Exception("Alguno de estos nodos no pertenecen al grafo");

            nodoInicio.Distancia = 0;
            int numeroVisitados = 0;
            
            while (true)
            {
                if (nodoInicio == null)
                    break;
                
                if (!nodoInicio.Visitado)
                    numeroVisitados += 1;

                nodoInicio.Visitado = true;

                for (int i = 0; i < Size; ++i)
                {
                    if (Matriz[nodoInicio.Index, i] != null)
                    {
                        if (nodoInicio.Distancia + Matriz[nodoInicio.Index, i].Item2 < Matriz[nodoInicio.Index, i].Item1.Distancia)
                        {
                            //El proximo nodo tendra referencia del nodo actual y una nueva distancia
                            Matriz[nodoInicio.Index, i].Item1.ParentNode = nodoInicio;
                            Matriz[nodoInicio.Index, i].Item1.Distancia = nodoInicio.Distancia + Matriz[nodoInicio.Index, i].Item2;
                        }
                    }
                }

                //El siguiente nodo será el que tenga la arista de menor precio
                int distanciaMinima = int.MaxValue;
                int indiceMinimo = 0;

                for (int i = 0; i < Size; ++i)
                {
                    if (Matriz[nodoInicio.Index, i] != null)
                    {
                        if ((Matriz[nodoInicio.Index, i].Item2 < distanciaMinima && !Matriz[nodoInicio.Index, i].Item1.Visitado) 
                            && Matriz[nodoInicio.Index, i].Item1.ParentNode.Index == nodoInicio.Index)
                        {
                            distanciaMinima = Matriz[nodoInicio.Index, i].Item2;
                            indiceMinimo = i;
                        }
                    }
                }

                if (distanciaMinima == int.MaxValue)
                {
                    nodoInicio = nodoInicio.ParentNode;
                    continue;
                }

                nodoInicio = Matriz[nodoInicio.Index, indiceMinimo].Item1;
            }

            nodoInicio = nodoFinal;

            while (nodoInicio.ParentNode != null)
            {
                Console.Write($"{nodoInicio.Index} <= ");
                nodoInicio = nodoInicio.ParentNode;
            }

            Console.WriteLine(nodoInicio.Index);                
        }

        Tuple<Node<T>, int>[,] ResizeArray()
        {
            Tuple<Node<T>, int>[,] newArray = new Tuple<Node<T>, int>[Capacity * 2, Capacity * 2];
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
