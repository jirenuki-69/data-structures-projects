using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Super;
using System.Runtime.Remoting.Messaging;

namespace SuperForms
{
    public partial class Form1 : Form
    {
        static int MAX_NUM_CLIENTS = 10;
        static int MAX_NUM_PRODUCTS = 8;
        static int MAX_CLIENT_DELAY = 3;
        static int EXPRESS_LANE_MAX_PRODUCTS = 4;
        int iteracion = 0;
        int numClientes = 1;

        List<Cliente> clientes = new List<Cliente>();
        Caja[] cajas = new Caja[5];
        ArrayQueue<Cliente> clientesEnEspera = new ArrayQueue<Cliente>(0);

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < cajas.Length; ++i)
            {
                if (i == cajas.Length - 1)
                {
                    cajas[i] = new Caja(3, EXPRESS_LANE_MAX_PRODUCTS); 
                    continue;
                }

                cajas[i] = new Caja(2);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            iteracion = 0;
            labelITERACION.Text = $"ITERACIÓN: {iteracion}";
        }

        private void btnIterar_Click(object sender, EventArgs e)
        {
            iteracion += 1;
            labelITERACION.Text = $"ITERACIÓN: {iteracion}";

            for (int i = 0; i < clientes.Count; ++i)
            {
                clientes[i].ActualDelay += 1;

                if (clientes[i].ActualDelay > clientes[i].Delay)
                {
                    clientesEnEspera.EnQueue(clientes[i]);
                    clientes.RemoveAt(i);
                }
            }

            AddNewClients();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
            btnDetener.Enabled = true;
            btnReiniciar.Enabled = false;
            btnIterar.Enabled = false;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            btnDetener.Enabled = false;
            btnReiniciar.Enabled = true;
            btnIterar.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AddNewClients()
        {
            Random random = new Random();

            //Genero n número de clientes donde n va de entre 0 y MAX_NUM_CLIENTS
            for (int i = 0; i < random.Next(1, MAX_NUM_CLIENTS); ++i)
            {
                int numProducts = random.Next(1, MAX_NUM_PRODUCTS);
                int delay = random.Next(1, MAX_CLIENT_DELAY);

                //Agrego el nuevo cliente a mi lista de todos los clientes
                clientes.Add(
                    new Cliente(
                        numClientes,
                        numProducts,
                        iteracion,
                        delay
                    )
                );

                //Aumento el número de clientes
                numClientes += 1;
            }

            RefreshClientTextBoxes();
            RefreshCajas();
        }

        private void RefreshClientTextBoxes()
        {
            string data = string.Empty;

            for (int i = 0; i < clientes.Count; ++i)
            {
                data += clientes[i].ToString();
            }

            txtSUPER.Text = data;
        }

        private void RefreshCajas() //Refresco el estado de los textbox que representan mis cajas
        {
            //Primero verifico si hay clientes esperando para caja por lo menos
            if (clientesEnEspera.IsEmpty())
            {
                return;
            }

            int n = clientesEnEspera.Size;

            for (int i = 0; i < n; ++i)
            {
                if (clientesEnEspera.Head.NumeroArticulos <= EXPRESS_LANE_MAX_PRODUCTS) //Si ese cliente en espera cumple con el criterio de productos de la caja rápida
                {
                    cajas[4].Clientes.EnQueue(clientesEnEspera.DeQueue());
                } 
                else //Si el cliente no cumple con el criterio...
                {
                    Random random = new Random();
                    int cajaIndex = random.Next(0, 4); //Cualquiera de las cajas disponibles, le agrego ese cliente

                    cajas[cajaIndex].Clientes.EnQueue(clientesEnEspera.DeQueue());
                }
            }

            for (int i = 0; i < cajas.Length; ++i)
            {
                switch (i)
                {
                    case 0:
                        if (cajas[i].Clientes.Size > 0)
                        {
                            string data = string.Empty;

                            for (int j = 0; j < cajas[i].Clientes.Size; ++j)
                            {
                                data += cajas[i].Clientes[j].ToString();
                            }

                            txtCAJA1.Text = data;
                        }

                        continue;
                    case 1:
                        if (cajas[i].Clientes.Size > 0)
                        {
                            string data = string.Empty;

                            for (int j = 0; j < cajas[i].Clientes.Size; ++j)
                            {
                                data += cajas[i].Clientes[j].ToString();
                            }

                            txtCAJA2.Text = data;
                        }

                        continue;
                    case 2:
                        if (cajas[i].Clientes.Size > 0)
                        {
                            string data = string.Empty;

                            for (int j = 0; j < cajas[i].Clientes.Size; ++j)
                            {
                                data += cajas[i].Clientes[j].ToString();
                            }

                            txtCAJA3.Text = data;
                        }

                        continue;
                    case 3:
                        if (cajas[i].Clientes.Size > 0)
                        {
                            string data = string.Empty;

                            for (int j = 0; j < cajas[i].Clientes.Size; ++j)
                            {
                                data += cajas[i].Clientes[j].ToString();
                            }

                            txtCAJA4.Text = data;
                        }

                        continue;
                    case 4:
                        if (cajas[i].Clientes.Size > 0)
                        {
                            string data = string.Empty;

                            for (int j = 0; j < cajas[i].Clientes.Size; ++j)
                            {
                                data += cajas[i].Clientes[j].ToString();
                            }

                            txtCAJARAPIDA.Text = data;
                        }

                        continue;
                }
            }
        }
    }
}

