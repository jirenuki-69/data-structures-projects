using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    interface IGraph<T>
    {
        int Size { get; }

        Node<T> AgregarNodo();
        void AgregarArista(Node<T> firstNode, Node<T> secondNode);
        void AgregarArista(Node<T> firstNode, Node<T> secondNode, int precio);
    }
}
