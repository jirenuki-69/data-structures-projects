using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>, IEnumerable
    {
        private T[] data;
        private int minimumCapacity;

        public int Size { get; private set; }
        public int Capacity { get; private set; }

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public ArrayList(int capacity)
        {
            data = new T[capacity];
            minimumCapacity = capacity;
            Size = 0;
            Capacity = capacity;
        }

        public ArrayList(ArrayList<T> list)
        {
            data = (T[])list.data.Clone();
            minimumCapacity = list.minimumCapacity;
            Size = list.Size;
            Capacity = list.Capacity;
        }

        public T Get(int index) => data[index];
        public void Set(int index, T element) => data[index] = element;

        public void Add(T element)
        {
            if (Size == Capacity) // size x 2 criteria
            {
                Array.Resize<T>(ref data, 2 * Capacity);
                Capacity *= 2;
            }

            data[Size++] = element;
        }

        public void Insert(int index, T element)
        {
            if (Size == Capacity) // size x 2 criteria
            {
                Array.Resize<T>(ref data, 2 * Capacity);
                Capacity *= 2;
            }

            if (index == Size)
            {
                data[Size++] = element;
            }
            else
            {
                for (int i = Size - 1; i >= index; --i)
                {
                    data[i + 1] = data[i];
                }

                data[index] = element;
                Size++;
            }
        }

        public T Remove(int index)
        {
            if (index >= Size)
            {
                throw new IndexOutOfRangeException();
            }

            T backup = data[index];
            for (int i = index; i < Size - 1; ++i)
            {
                data[i] = data[i + 1];
            }

            data[--Size] = default;

            // Reducir capacidad...

            return backup;
        }

        public bool IsEmpty() => Size == 0;

        public void ForEach(Action<T> action)
        {
            foreach (T value in data)
            {
                action(value);
            }
        }

        public T Find(Predicate<T> criteria)
        {
            foreach (T value in data)
            {
                if (criteria(value))
                {
                    return value;
                }
            }

            return default;
        }

        private class Enumerator : IEnumerator
        {
            private int currentIndex;
            private ArrayList<T> list;

            public Enumerator(ArrayList<T> list)
            {
                this.list = list;
                currentIndex = -1;
            }

            public object Current => list[currentIndex];

            public bool MoveNext()
            {
                if (currentIndex + 1 == list.Size)
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
