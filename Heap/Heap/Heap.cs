using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Heap<T> : IHeap<T>
    {
        List<T> data;
        public int Size { get => data.Count; }

        public T Min { get {
            if (IsEmpty())
                throw new Exception("Empty Heap");

            return data[0];
        } }

        public T RemoveMin { get  {
            if (IsEmpty())
                throw new Exception("Empty Heap");

            T element = Min;
            data[0] = data[Size - 1];
            data.RemoveAt(Size - 1);

            DownHeapBubbling(0);

            return element;
        } }

        public T this[int index] => data[index];

        private Func<T, T, int> Comparer { get; set; }

        public Heap(Func<T, T, int> func)
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new Exception("Object of Type <T> must implement the Icomparable Interface");

            data = new List<T>();
            Comparer = func;
        }

        public bool IsEmpty() => Size == 0;

        public void Insert(T element)
        {
            data.Add(element);

            UpHeapBubbling(Size - 1);
        }

        static public void HeapSort(List<T> list, Func<T, T, int> func)
        {
            Heap<T> newHeap = Heapify(list, func);
            List<T> newList = new List<T>();

            while (newHeap.Size != 0)
            {
                //Agarro los elementos que se consideran los más pequeños y los agrego a la nueva lista
                newList.Add(newHeap.RemoveMin);
            }

            //Hago un ForEach a la nueva lista que ya tiene los elementos ordenados y los agrego a la lista original
            newList.ForEach(element => list.Add(element));
        }

        static public Heap<T> Heapify(List<T> list, Func<T, T, int> func)
        {
            Heap<T> newHeap = new Heap<T>(func);

            newHeap.data = list;

            int index = list.Count - 1;
            int maxHeight = newHeap.GetElementHeight(index);

            while (true)
            {
                if (newHeap.GetElementHeight(index) < maxHeight)
                    break;

                index -= 1;
            }

            int n = index + 1;

            for (int i = 0; i < n; ++i)
            {
                newHeap.DownHeapBubbling(index);
                index -= 1;
            }

            return newHeap;
        }

        private void UpHeapBubbling(int currentIndex)
        {
            if (currentIndex == 0)
                return;

            int parentIndex = GetParentIndex(currentIndex);

            //Si el padre es menor al hijo
            if (Comparer(data[parentIndex], data[currentIndex]) < 0)
                return;

            //Intercambio de padre e hijo
            T element = data[parentIndex];
            data[parentIndex] = data[currentIndex];
            data[currentIndex] = element;

            UpHeapBubbling(parentIndex);
        }

        private void DownHeapBubbling(int currentIndex)
        {
            int indexLeftChild = GetLeftChildIndex(currentIndex);
            int indexRightChild = GetRightChildIndex(currentIndex);

            //Si el elemento actual no tiene hijos, retorno como si nada
            if (indexLeftChild >= Size && indexRightChild >= Size)
                return;

            //Si el hijo derecho no existe, significa que el izquierdo sí
            else if (indexRightChild >= Size)
            {
                if (indexLeftChild < Size)
                {
                    if (Comparer(data[indexLeftChild], data[currentIndex]) < 0 && Comparer(data[indexLeftChild], data[currentIndex]) < 0) 
                    {
                        //Intercambio del hijo izquierdo con el padre
                        T element = data[indexLeftChild];
                        data[indexLeftChild] = data[currentIndex];
                        data[currentIndex] = element;
                    }
                }

                return;
            }

            //Si el hijo izquierdo es el menor de los dos y el hijo es menor al padre
            if (Comparer(data[indexLeftChild], data[indexRightChild]) < 0 && Comparer(data[indexLeftChild], data[currentIndex]) < 0)
            {
                //Intercambio del hijo izquierdo con el padre
                T element = data[indexLeftChild];
                data[indexLeftChild] = data[currentIndex];
                data[currentIndex] = element;

                DownHeapBubbling(indexLeftChild);
            }

            //Si el hijo derecho es el menor de los dos y el hijo es menor al padre
            else if (Comparer(data[indexRightChild], data[indexLeftChild]) < 0 && Comparer(data[indexRightChild], data[currentIndex]) < 0)
            {
                //Intercambio del hijo derecho con el padre
                T element = data[indexRightChild];
                data[indexRightChild] = data[currentIndex];
                data[currentIndex] = element;

                DownHeapBubbling(indexRightChild);
            }
            //Si son iguales, por defecto se va al izquierdo y el hijo es menor al padre
            else if (Comparer(data[indexLeftChild], data[currentIndex]) < 0)
            {
                //Intercambio del hijo izquierdo con el padre
                T element = data[indexLeftChild];
                data[indexLeftChild] = data[currentIndex];
                data[currentIndex] = element;

                DownHeapBubbling(indexLeftChild);
            }
        }

        public override string ToString()
        {
            string array = $"S: {Size} [ ";

            for (int i = 0; i < Size; ++i)
            {
                array += $"{data[i]} ";
            }

            array += "]";

            return array;
        }

        private int GetElementHeight(int index) => Convert.ToInt32(Math.Truncate(Math.Log(index + 1, 2)));
        private int GetParentIndex(int index) => (index - 1) / 2;
        private int GetLeftChildIndex(int index) => 2 * index + 1;
        private int GetRightChildIndex(int index) => 2 * index + 2;
    }
}
