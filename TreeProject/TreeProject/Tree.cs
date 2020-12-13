using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeProject
{
    class Tree<T> : ITree<T>, IEnumerable
    {
        public int Size { get; private set; }

        public int Height { get => MaxHeight(RootNode); }

        public Node<T> RootNode { get; private set; }

        public enum ProcessOrder { InOrder, PreOrder, PostOrder };

        public Tree()
        {
            Size = 0;
            RootNode = null;
        }

        public bool IsEmpty() => RootNode == null;

        public Node<T> AddRoot(T data)
        {
            //Verifico si hay un root y si entra, devuelvo un error
            if (!IsEmpty())
            {
                throw new Exception("Ya existe un nodo raíz ;)");
            }

            RootNode = new Node<T>(data, Height);

            Size++;
            return RootNode;
        }

        public Node<T> AddLeftChild(Node<T> node, T data)
        {
            if (IsEmpty())
                throw new Exception("No hay ningún nodo para agregar un hijo izquierdo ;(");

            //Si ya tiene un nodo izquierdo retorno error
            else if (node.LeftNode != null)
                throw new Exception("Este nodo ya tiene un hijo izquierdo");

            //Nodo es root y el root no tiene hijo izquierdo
            if (node.ParentNode == null && RootNode.LeftNode == null)
            {
                Node<T> nuevoNodo = new Node<T>(data, 1);
                nuevoNodo.ParentNode = RootNode;

                RootNode.LeftNode = nuevoNodo;
                Size++;

                return nuevoNodo;
            }

            //Creo un nuevo nodo y se lo agrego al nodo que se quiere agregar el hijo
            Node<T> newNode = new Node<T>(data, node.Height + 1);
            newNode.ParentNode = node;
            node.LeftNode = newNode;
            Size++;

            return newNode;
        }

        public Node<T> AddRightChild(Node<T> node, T data)
        {
            if (IsEmpty())
                throw new Exception("No hay ningún nodo para agregar un hijo derecho ;(");

            //Si ya tiene un nodo derecho retorno error
            else if (node.RightNode != null)
                throw new Exception("Este nodo ya tiene un hijo derecho");

            if (node.ParentNode == null && RootNode.RightNode == null)
            {
                Node<T> nuevoNodo = new Node<T>(data, 1);
                nuevoNodo.ParentNode = RootNode;

                RootNode.RightNode = nuevoNodo;
                Size++;
                return nuevoNodo;
            }

            //Creo un nuevo nodo y se lo agrego al nodo que se quiere agregar el hijo
            Node<T> newNode = new Node<T>(data, node.Height + 1);
            newNode.ParentNode = node;
            node.RightNode = newNode;
            Size++;

            return newNode;
        }

        public void DeleteNode(Node<T> node, bool withChildren)
        {
            if (IsEmpty())
                throw new Exception("No hay nodos en el contexto actual para eliminar");

            if (node == RootNode)
            {
                WithChildrenAlgorithm(RootNode);
                RootNode = null;
                return;
            }

            if (!withChildren)
            {
                if (node.LeftNode != null && node.RightNode != null)
                    throw new Exception("No es un nodo hoja o tiene dos hijos");
            }

            WithChildrenAlgorithm(node);

            if (node.IsLeftChild())
                node.ParentNode.LeftNode = null;
            else
                node.ParentNode.RightNode = null;
        }

        public void ForEach(Action<T> action, int order)
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException();
            }

            if (order == 1)
                Order(RootNode, ProcessOrder.PreOrder, action);
            else if (order == 2)
                Order(RootNode, ProcessOrder.InOrder, action);
            else if (order == 3)
                Order(RootNode, ProcessOrder.PostOrder, action);
            else
                throw new Exception("?");
        }

        public List<T> TreeSort(Comparison<T> comparison)
        {
            List<T> list = new List<T>();

            foreach (T e in this)
                list.Add(e);

            list.Sort(comparison);

            return list;
        }

        private int MaxHeight(Node<T> currentNode)
        {
            if (currentNode == null)
                return 0;
            else
            {
                int leftHeight = MaxHeight(currentNode.LeftNode);
                int rightHeight = MaxHeight(currentNode.RightNode);

                if (currentNode.IsLeaf())
                    return 0;
                else if (leftHeight > rightHeight)
                    return leftHeight + 1;
                else
                    return rightHeight + 1;
            }
        }

        void WithChildrenAlgorithm(Node<T> currentNode)
        {
            if (currentNode == null || currentNode.IsLeaf())
            {
                currentNode = null;
                Size--;
                return;
            }

            if (currentNode.LeftNode != null)
                WithChildrenAlgorithm(currentNode.LeftNode);

            if (currentNode.RightNode != null)
                WithChildrenAlgorithm(currentNode.RightNode);

            currentNode = null;
            Size--;
            return;
        }

        private void Order(Node<T> currentNode, ProcessOrder processOrder, Action<T> action)
        {
            if (processOrder == ProcessOrder.PreOrder)
                action(currentNode.Data);

            if (currentNode.LeftNode != null)
                Order(currentNode.LeftNode, processOrder, action);

            if (processOrder == ProcessOrder.InOrder)
                action(currentNode.Data);

            if (currentNode.RightNode != null)
                Order(currentNode.RightNode, processOrder, action);

            if (processOrder == ProcessOrder.PostOrder)
                action(currentNode.Data);

            if (currentNode.IsLeaf())
                return;

            return;
        }
        
        private class Enumerator : IEnumerator
        {
            private int currentIndex;
            private List<T> list = new List<T>();

            public Enumerator(Tree<T> tree)
            {
                tree.ForEach(element => list.Add(element), 2);
                currentIndex = -1;
            }

            public object Current => list[currentIndex];

            public bool MoveNext()
            {
                if (currentIndex + 1 == list.Count)
                {
                    return false;
                }

                currentIndex++;
                return true;
            }

            public void Reset() => currentIndex = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
