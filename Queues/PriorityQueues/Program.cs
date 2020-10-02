using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo varios alumnos para compararlos
            Alumno alumno1 = new Alumno("Miguel", 9.3, 8.1, 9.0);
            Alumno alumno2 = new Alumno("Abraham", 8.0, 9.2, 10.0);
            Alumno alumno3 = new Alumno("Russell", 10.0, 7.2, 8.3);
            Alumno alumno4 = new Alumno("Puki", 8.8, 8.1, 7.3);
            Alumno alumno5 = new Alumno("Willy", 9.1, 8.8, 9.2);
            Alumno alumno6 = new Alumno("Paco", 8.1, 7.3, 9.5);
            Alumno alumno7 = new Alumno("Sinuhe", 7.4, 8.6, 9.8);
            //El usuario ingresa su propia prioridad
            ArrayPriorityQueue<Alumno> priorityQueue 
                = new ArrayPriorityQueue<Alumno>(5, (a, b) => b.Promedio.CompareTo(a.Promedio)); 

            priorityQueue.EnQueue(alumno1);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            priorityQueue.EnQueue(alumno2);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            priorityQueue.EnQueue(alumno3);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            priorityQueue.EnQueue(alumno4);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            Console.WriteLine($"Priority Popping: {priorityQueue.PriorityDequeue()}");
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            Console.WriteLine($"Priority Peek: {priorityQueue.PriorityPeek()}");
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            priorityQueue.EnQueue(alumno5);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            priorityQueue.EnQueue(alumno6);
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            priorityQueue.EnQueue((alumno7));
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            Console.WriteLine($"Priority Popping: {priorityQueue.PriorityDequeue()}");
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            Console.WriteLine($"Priority Popping: {priorityQueue.PriorityDequeue()}");
            Console.WriteLine(priorityQueue);

            Console.WriteLine($"Head: {priorityQueue.Head}\nTail: { priorityQueue.Tail}\n");

            Console.ReadKey();
        }
    }
    class Alumno
    {
        private string nombre;
        private double promedioPrimerSemestre, promedioSegundoSemestre, promedioTercerSemestre, promedio;

        public string Nombre { get => nombre; set => nombre = value; }
        public double PromedioPrimerSemestre { get => promedioPrimerSemestre; set => promedioPrimerSemestre = value; }
        public double PromedioSegundoSemestre { get => promedioSegundoSemestre; set => promedioSegundoSemestre = value; }
        public double PromedioTercerSemestre { get => promedioTercerSemestre; set => promedioTercerSemestre = value; }
        public double Promedio { get => promedio; set => promedio = value; }

        public Alumno() { }

        public Alumno(string nombre, double promedioPrimerSemestre, double promedioSegundoSemestre, double promedioTercerSemestre)
        {
            this.nombre = nombre;
            this.promedioPrimerSemestre = promedioPrimerSemestre;
            this.promedioSegundoSemestre = promedioSegundoSemestre;
            this.promedioTercerSemestre = promedioTercerSemestre;
            this.promedio = Math.Round((promedioPrimerSemestre * promedioSegundoSemestre * promedioTercerSemestre) / 3, 2);
        }
        public override string ToString() => nombre; //Cada que mando un WriteLine o ToString() esta función se ejecuta
    }
}
