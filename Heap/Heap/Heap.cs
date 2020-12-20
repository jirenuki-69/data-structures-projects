using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Heap<T> : IHeap<T>
    {
        List<T> data = new List<T>();
        public int Size { get => data.Count; private set { } }

        public T Min { get {
            if (IsEmpty())
                throw new Exception("Empty Heap");

            T element = data[0];
            int index = default;

            for (int i = 0; i < Size; ++i)
            {
                //Si el elemento actual el mayor al siguiente dato
                if (Comparer<T>.Default.Compare(data[i], element) < 0) 
                {
                    element = data[i]; 
                    index = i;
                }
            }

            return data[index];
        }  }

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

        public Heap()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new Exception("Object of Type <T> must implement the Icomparable Interface");

            Size = 0;
        }

        public bool IsEmpty() => Size == 0;

        public void Insert(T element)
        {
            data.Add(element);

            UpHeapBubbling(Size - 1);
        }

        static public void HeapSort(List<T> list)
        {
            Heap<T> newHeap = Heapify(list);
            List<T> newList = new List<T>();

            while (newHeap.Size != 0)
            {
                newList.Add(newHeap.RemoveMin);
            }

            newList.ForEach(element => list.Add(element));
        }

        static public Heap<T> Heapify(List<T> list)
        {
            Heap<T> newHeap = new Heap<T>();

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
            if (Comparer<T>.Default.Compare(data[parentIndex], data[currentIndex]) < 0)
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

            if (indexLeftChild >= Size && indexRightChild >= Size)
                return;

            else if (indexLeftChild >= Size || indexRightChild >= Size)
            {
                if (indexLeftChild < Size)
                {
                    if (Comparer<T>.Default.Compare(data[indexLeftChild], data[currentIndex]) < 0 && Comparer<T>.Default.Compare(data[indexLeftChild], data[currentIndex]) < 0) 
                    {
                        T element = data[indexLeftChild];
                        data[indexLeftChild] = data[currentIndex];
                        data[currentIndex] = element;
                    }
                }
                else if (indexRightChild < Size)
                {
                    if (Comparer<T>.Default.Compare(data[indexRightChild], data[currentIndex]) < 0 && Comparer<T>.Default.Compare(data[indexRightChild], data[currentIndex]) < 0)
                    {
                        T element = data[indexRightChild];
                        data[indexRightChild] = data[currentIndex];
                        data[currentIndex] = element;
                    }
                }

                return;
            }

            //Si el hijo izquierdo es el menor de los dos
            if (Comparer<T>.Default.Compare(data[indexLeftChild], data[indexRightChild]) < 0 && Comparer<T>.Default.Compare(data[indexLeftChild], data[currentIndex]) < 0)
            {
                T element = data[indexLeftChild];
                data[indexLeftChild] = data[currentIndex];
                data[currentIndex] = element;

                DownHeapBubbling(indexLeftChild);
            }

            //Si el hijo derecho es el menor de los dos
            else if (Comparer<T>.Default.Compare(data[indexRightChild], data[indexLeftChild]) < 0 && Comparer<T>.Default.Compare(data[indexRightChild], data[currentIndex]) < 0)
            {
                T element = data[indexRightChild];
                data[indexRightChild] = data[currentIndex];
                data[currentIndex] = element;

                DownHeapBubbling(indexRightChild);
            }
            //Si son iguales, por defecto se va al izquierdo
            else if (Comparer<T>.Default.Compare(data[indexLeftChild], data[currentIndex]) < 0)
            {
                T element = data[indexLeftChild];
                data[indexLeftChild] = data[currentIndex];
                data[currentIndex] = element;

                DownHeapBubbling(indexLeftChild);
            }
        }

        public override string ToString()
        {
            string array = "[ ";

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
