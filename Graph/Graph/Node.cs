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
        Graph<T> graph;

        public int Index { get => index; set => index = value; }
        public Graph<T> Graph { get => graph; set => graph = value; }

        public Node(int index, Graph<T> graph)
        {
            this.index = index;
            this.graph = graph;
        }
    }
}
