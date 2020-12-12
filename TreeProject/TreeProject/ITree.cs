using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProject
{
    interface ITree<T>
    {
        int Size { get; }
        int Height { get; }
        Node<T> RootNode { get; }
        bool IsEmpty();
        Node<T> AddRoot(T data);
        Node<T> AddLeftChild(Node<T> node, T data);
        Node<T> AddRightChild(Node<T> node, T data);
        void DeleteNode(Node<T> node, bool withChildren);
        void ForEach(Action<T> action, int order);
    }
}
