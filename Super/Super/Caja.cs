using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super
{
    public class Caja
    {
        int maximoProductos, checkout;
        ArrayQueue<Cliente> clientes = new ArrayQueue<Cliente>(0);

        public int MaximoProductos { get => maximoProductos; set => maximoProductos = value; }
        public int Checkout { get => checkout; set => checkout = value; }
        public ArrayQueue<Cliente> Clientes { get => clientes; set => clientes = value; }

        public Caja(int num) => checkout = num;

        public Caja(int num, int productos)
        {
            checkout = num;
            maximoProductos = productos;
        }
    }
}
