using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super
{
    public class Caja
    {
        int maximoProductos, CHECKOUT_NUM_OF_PRODUCTS;
        ArrayQueue<Cliente> clientes = new ArrayQueue<Cliente>(0);

        public int MaximoProductos { get => maximoProductos; set => maximoProductos = value; }
        public int _CHECKOUT_NUM_OF_PRODUCTS { get => CHECKOUT_NUM_OF_PRODUCTS; set => CHECKOUT_NUM_OF_PRODUCTS = value; }
        public ArrayQueue<Cliente> Clientes { get => clientes; set => clientes = value; }

        public Caja(int num) => CHECKOUT_NUM_OF_PRODUCTS = num;

        public Caja(int num, int productos)
        {
            CHECKOUT_NUM_OF_PRODUCTS = num;
            maximoProductos = productos;
        }
    }
}
