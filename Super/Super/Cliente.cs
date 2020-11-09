using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super
{
    public class Cliente
    {
        int id, numeroArticulos, entrada, salida, delay, actualDelay;

        public Cliente(int id, int numeroArticulos, int entrada, int delay)
        {
            this.id = id;
            this.numeroArticulos = numeroArticulos;
            this.entrada = entrada;
            this.delay = delay;
            actualDelay = 0;
            salida = 0;
        }

        public int ID { get => id; set => id = value; }
        public int NumeroArticulos { get => numeroArticulos; set => numeroArticulos = value; }
        public int Entrada { get => entrada; set => entrada = value; }
        public int Salida { get => salida; set => salida = value; }
        public int Delay { get => delay; set => delay = value; }
        public int ActualDelay { get => actualDelay; set => actualDelay = value; }

        public override string ToString()
        {
            string data =
                $"ID: {id}\n" +
                $"Número de productos: {numeroArticulos}\n" +
                $"Delay: {actualDelay}\n" +
                $"Máximo Delay: {delay}\n" +
                $"Entrada: {entrada}\n" +
                "----------------------\n"
            ;
            return data;
        }

        public string ToStringExit()
        {
            string data =
                $"ID: {id}\n" +
                $"Número de productos: {numeroArticulos}\n" +
                $"Delay: {actualDelay}\n" +
                $"Máximo Delay: {delay}\n" +
                $"Entrada: {entrada}\n" +
                $"Salida: {salida}\n" +
                "----------------------\n"
            ;
            return data;
        }
    }
}
