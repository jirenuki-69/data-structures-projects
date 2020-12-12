using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProject
{
    class Node<T>
    {
        public Node<T> ParentNode { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public T Data { get; set; }
        public int Height { get; set; }

        public Node(T element, int height = 0)
        {
            Data = element;
            Height = height;
        }

        //Si no tiene hijos, es un nodo hoja
        public bool IsLeaf() => LeftNode == null && RightNode == null;

        //Si tiene algún hijo, es un nodo padre
        public bool HasChildren()
        {
            if (LeftNode != null || RightNode != null)
                return true;

            return false;
        }

        public Node<T> GetSibling()
        {
            //Si es root, retorno nulo
            if (ParentNode == null)
                return null;

            //Agarro los dos hijos del nodo padre ;)
            Node<T> leftChildrenNode = ParentNode.LeftNode;
            Node<T> rightChildrenNode = ParentNode.RightNode;
            
            
            if (leftChildrenNode != null || rightChildrenNode != null)
            {
                //Si el hijo izquierdo del padre es este y el derecho no es nul, devuelvo el hijo derecho como el hermano del nodo actual
                if ((leftChildrenNode == this && rightChildrenNode != null))
                    return rightChildrenNode;

                //Lo mismo de arriba sólo que alrevés
                if ((leftChildrenNode != null && rightChildrenNode == this))
                    return leftChildrenNode;
            }

            //Si no hay hermano, retorno nulo por default
            return null;
        }

        public bool IsLeftChild()
        {
            if (ParentNode.LeftNode == this)
                return true;

            return false;
        }
    }
}
