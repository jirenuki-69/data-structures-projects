using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>(5);

            //Creando los nodos del grafo
            Node<int> nodoUno = graph.AgregarNodo();
            Node<int> nodoDos = graph.AgregarNodo();
            Node<int> nodoTres = graph.AgregarNodo();
            Node<int> nodoCuatro = graph.AgregarNodo();
            Node<int> nodoCinco = graph.AgregarNodo();
            Node<int> nodoSeis = graph.AgregarNodo();
            Node<int> nodoSiete = graph.AgregarNodo();

            //Conectando los nodos con aristas
            graph.AgregarArista(nodoUno, nodoDos, 2);
            graph.AgregarArista(nodoUno, nodoCuatro);
            graph.AgregarArista(nodoDos, nodoCuatro, 3);
            graph.AgregarArista(nodoDos, nodoCinco, 10);
            graph.AgregarArista(nodoTres, nodoUno, 4);
            graph.AgregarArista(nodoTres, nodoSeis, 5);
            graph.AgregarArista(nodoCuatro, nodoTres, 2);
            graph.AgregarArista(nodoCuatro, nodoCinco, 2);
            graph.AgregarArista(nodoCuatro, nodoSeis, 8);
            graph.AgregarArista(nodoCuatro, nodoSiete, 4);
            graph.AgregarArista(nodoCinco, nodoSiete, 6);
            graph.AgregarArista(nodoSiete, nodoSeis);

            graph.MostrarMatriz();

            graph.ShortestPath(nodoTres, nodoCinco);

            Console.ReadKey();
        }
    }
}
