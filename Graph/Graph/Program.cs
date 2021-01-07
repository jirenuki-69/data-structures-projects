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
            graph.AgregarArista(nodoUno, nodoDos, 3);
            graph.AgregarArista(nodoDos, nodoTres, 5);
            graph.AgregarArista(nodoTres, nodoCuatro);
            graph.AgregarArista(nodoCuatro, nodoCinco, 2);
            graph.AgregarArista(nodoCinco, nodoTres, 8);
            graph.AgregarArista(nodoCinco, nodoSeis, 4);
            graph.AgregarArista(nodoSeis, nodoUno, 7);
            graph.AgregarArista(nodoSeis, nodoSiete);
            graph.AgregarArista(nodoSiete, nodoDos, 2);
            graph.AgregarArista(nodoSiete, nodoTres);

            graph.MostrarMatriz();

            Console.ReadKey();
        }
    }
}
