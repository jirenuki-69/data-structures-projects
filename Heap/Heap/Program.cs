using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap<Vehiculo> heap = new Heap<Vehiculo>((element, element2) => element.Nombre.CompareTo(element2.Nombre));

            Console.WriteLine("***HEAP DE VEHÍCULOS***");

            heap.Insert(new Vehiculo(200, "Honda"));
            heap.Insert(new Vehiculo(220, "Ferrari"));
            heap.Insert(new Vehiculo(230, "Audi"));
            heap.Insert(new Vehiculo(210, "Suzuki"));
            heap.Insert(new Vehiculo(120, "Toyota"));
            heap.Insert(new Vehiculo(130, "Ford"));
            heap.Insert(new Vehiculo(320, "Porsche"));

            Console.WriteLine(heap);

            Console.WriteLine($"RemoveMin: {heap.RemoveMin.Nombre}");
            Console.WriteLine($"RemoveMin: {heap.RemoveMin.Nombre}");
            Console.WriteLine($"RemoveMin: {heap.RemoveMin.Nombre}");
            Console.WriteLine($"RemoveMin: {heap.RemoveMin.Nombre}");
            Console.WriteLine($"RemoveMin: {heap.RemoveMin.Nombre}");

            Console.WriteLine(heap);

            //Console.WriteLine(heap);

            Console.WriteLine();

            Console.WriteLine("***HEAPIFY***");

            List<int> list = new List<int>() { 14, 5, 8, 25, 9, 11, 17, 16, 15, 4, 12, 6, 7, 23, 20 };

            Heap<int> newHeap = Heap<int>.Heapify(list, (element, element2) => element.CompareTo(element2));

            Console.WriteLine(newHeap);

            Console.WriteLine();

            Console.WriteLine("***HEAPSORT***");

            Heap<int>.HeapSort(list, (element, element2) => element.CompareTo(element2));

            Console.Write("[ ");

            list.ForEach(element => Console.Write($"{element} "));

            Console.WriteLine("]");

            Console.ReadKey();
        }
    }

    class Vehiculo : IComparable
    {
        int velocidad;
        string nombre;

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Vehiculo(int velocidad, string nombre)
        {
            this.velocidad = velocidad;
            this.nombre = nombre;
        }

        public int CompareTo(object obj)
        {
            Vehiculo aux = obj as Vehiculo;
            return velocidad.CompareTo(aux.Velocidad);
        }

        public override string ToString() => $"({nombre}, {velocidad})";
    }
}
