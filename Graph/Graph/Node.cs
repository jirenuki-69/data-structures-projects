using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Node<T>
    {
        int index;
        int distancia = int.MaxValue;
        bool visitado = false;
        Node<T> parentNode;
        Graph<T> graph;

        public int Index { get => index; set => index = value; }
        public int Distancia { get => distancia; set => distancia = value; }
        public Graph<T> Graph { get => graph; set => graph = value; }
        public bool Visitado { get => visitado; set => visitado = value; }
        public Node<T> ParentNode { get => parentNode; set => parentNode = value; }

        public Node(int index, Graph<T> graph)
        {
            this.index = index;
            this.graph = graph;
        }
    }
}
