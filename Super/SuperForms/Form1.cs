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
using ArrayList;
using System.Runtime.Remoting.Messaging;

namespace SuperForms
{
    public partial class Form1 : Form
    {
        static int[] DEFAULT_VALUES = new int[] { 10, 8, 3, 4 };
        public int MAX_NUM_CLIENTS = DEFAULT_VALUES[0];
        public int MAX_NUM_PRODUCTS = DEFAULT_VALUES[1];
        public int MAX_CLIENT_DELAY = DEFAULT_VALUES[2];
        public int EXPRESS_LANE_MAX_PRODUCTS = DEFAULT_VALUES[3];
        int iteracion = 0;
        int numClientes = 1;
        bool clientExistsInCaja = false;
        bool timerInitialized = false;

        Caja[] cajas = new Caja[5];
        ArrayList<Cliente> clientes = new ArrayList<Cliente>(4);
        ArrayList<Cliente> clientesSaliendo = new ArrayList<Cliente>(4);
        ArrayQueue<Cliente> clientesEnEspera = new ArrayQueue<Cliente>(0);

        System.Timers.Timer timer = new System.Timers.Timer(1000);

        public System.Timers.Timer Timer { get => timer; set => timer = value; }
        public Caja[] Cajas { get => cajas; set => cajas = value; }

        public Form1()
        {
            InitializeComponent();

            CenterTextBoxes();

            Control.CheckForIllegalCrossThreadCalls = false;

            for (int i = 0; i < cajas.Length; ++i)
            {
                if (i == cajas.Length - 1)
                {
                    cajas[i] = new Caja(2, EXPRESS_LANE_MAX_PRODUCTS);
                    continue;
                }

                cajas[i] = new Caja(1);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ResetAllControls();
        }

        private void btnIterar_Click(object sender, EventArgs e)
        {
            imgSETTINGS.Enabled = true;
            InitializeIteracion();
            AddNewClients();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!timerInitialized)
            {
                timer.Elapsed += Timer_Elapsed;
                timerInitialized = true;
            }

            btnDetener.Enabled = true;
            btnReiniciar.Enabled = false;
            btnIterar.Enabled = false;
            btnIniciar.Enabled = false;
            imgSETTINGS.Enabled = false;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            InitializeIteracion();
            AddNewClients();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            timer.Stop();
            btnDetener.Enabled = false;
            btnReiniciar.Enabled = true;
            btnIterar.Enabled = true;
            btnIniciar.Enabled = true;
            imgSETTINGS.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(
                MAX_NUM_CLIENTS,
                MAX_NUM_PRODUCTS,
                MAX_CLIENT_DELAY,
                EXPRESS_LANE_MAX_PRODUCTS,
                timer,
                cajas
            );
            settings.MainForm = this;

            settings.Show();
        }

        private void InitializeIteracion()
        {
            imgSETTINGS.Enabled = false;
            iteracion += 1;
            labelITERACION.Text = $"ITERACIÓN: {iteracion}";

            for (int i = 0; i < clientes.Size; ++i)
            {
                clientes[i].ActualDelay += 1;

                if (clientes[i].ActualDelay > clientes[i].Delay)
                {
                    clientesEnEspera.EnQueue(clientes[i]);
                    clientes.Remove(i);
                }
            }
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
            CenterTextBoxes();
        }

        private void RefreshClientTextBoxes()
        {
            string data = string.Empty;

            for (int i = 0; i < clientes.Size; ++i)
            {
                data += clientes[i].ToString();
            }

            txtSUPER.Text = data;
        }

        private void RefreshCajas() //Refresco el estado de los textbox que representan mis cajas
        {
            for (int i = 0; i < cajas.Length; ++i)
            {
                if (cajas[i].Clientes.Size > 0)
                {
                    clientExistsInCaja = true;
                }
            }

            //Primero verifico si hay clientes esperando para caja por lo menos y que no haya ningun cliente en alguna caja
            if (clientesEnEspera.IsEmpty() && !clientExistsInCaja)
            {
                return;
            }

            InitCheckouts();
            int n = clientesEnEspera.Size;

            for (int i = 0; i < n; ++i)
            {
                if (clientesEnEspera.Head.NumeroArticulos <= EXPRESS_LANE_MAX_PRODUCTS) //Si ese cliente en espera cumple con el criterio de productos de la caja rápida
                {
                    cajas[4].Clientes.EnQueue(clientesEnEspera.DeQueue());
                }
                else //Si el cliente no cumple con el criterio...
                {
                    int index = EscogerCaja(); //El cliente se irá a la primera caja que vea con menor número de clientes esperando en dicha caja

                    cajas[index].Clientes.EnQueue(clientesEnEspera.DeQueue());
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

        private int EscogerCaja()
        {
            int index = 0;
            int minimum = Cajas[index].Clientes.Size;

            for (int i = 0; i < cajas.Length - 1; ++i) //Todas las cajas
            {
                if (cajas[i].Clientes.Size < minimum) //Si en la caja en la que estoy tiene menor número de clientes esperando
                {
                    index = i;
                    minimum = cajas[index].Clientes.Size;
                }
            }

            return index;
        }

        private void InitCheckouts()
        {
            for (int i = 0; i < cajas.Length; ++i)
            {
                if (cajas[i].Clientes.Size == 0)
                {
                    continue;
                }

                cajas[i].Clientes.Head.NumeroArticulos -= cajas[i]._CHECKOUT_NUM_OF_PRODUCTS;

                if (cajas[i].Clientes.Head.NumeroArticulos <= 0)
                {
                    cajas[i].Clientes.Head.NumeroArticulos = 0;
                    cajas[i].Clientes.Head.Salida = iteracion;
                    clientesSaliendo.Add(cajas[i].Clientes.DeQueue());
                }
            }

            RefreshSalida();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Dispose();
        }

        private void ResetAllControls()
        {
            foreach (Control control in this.Controls)
            {
                if (control is RichTextBox)
                {
                    RichTextBox textBox = (RichTextBox)control;
                    textBox.Text = null;
                }

                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Enabled = true;
                }

                if (control is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)control;
                    pictureBox.Enabled = true;
                }
            }

            btnDetener.Enabled = false;
            DEFAULT_VALUES = new int[] { 10, 8, 3, 4 };
            MAX_NUM_CLIENTS = DEFAULT_VALUES[0];
            MAX_NUM_PRODUCTS = DEFAULT_VALUES[1];
            MAX_CLIENT_DELAY = DEFAULT_VALUES[2];
            EXPRESS_LANE_MAX_PRODUCTS = DEFAULT_VALUES[3];
            iteracion = 0;
            labelITERACION.Text = $"ITERACIÓN = {iteracion}";
            numClientes = 1;
            clientExistsInCaja = false;
            timerInitialized = false;
            clientes = new ArrayList<Cliente>(4);
            clientesSaliendo = new ArrayList<Cliente>(4);
            clientesEnEspera = new ArrayQueue<Cliente>(0);
            cajas = new Caja[5];

            timer.Dispose();
            timer = new System.Timers.Timer(1000);

            for (int i = 0; i < cajas.Length; ++i)
            {
                if (i == cajas.Length - 1)
                {
                    cajas[i] = new Caja(2, EXPRESS_LANE_MAX_PRODUCTS);
                    continue;
                }

                cajas[i] = new Caja(1);
            }
        }
        private void RefreshSalida()
        {
            txtCLIENTESSALIENDO.Text = "";

            for (int i = 0; i < clientesSaliendo.Size; ++i)
            {
                try
                {
                    txtCLIENTESSALIENDO.Text += clientesSaliendo[i].ToStringExit();
                } 
                catch(Exception e)
                {
                    MessageBox.Show("Ocurrió algo con el programa, favor de reiniciar");
                }
            }
        }

        private void CenterTextBoxes()
        {
            txtSUPER.SelectAll();
            txtSUPER.SelectionAlignment = HorizontalAlignment.Center;
            txtSUPER.DeselectAll();

            txtCAJA1.SelectAll();
            txtCAJA1.SelectionAlignment = HorizontalAlignment.Center;
            txtCAJA1.DeselectAll();

            txtCAJA1.SelectAll();
            txtCAJA1.SelectionAlignment = HorizontalAlignment.Center;
            txtCAJA1.DeselectAll();

            txtCAJA2.SelectAll();
            txtCAJA2.SelectionAlignment = HorizontalAlignment.Center;
            txtCAJA2.DeselectAll();

            txtCAJA3.SelectAll();
            txtCAJA3.SelectionAlignment = HorizontalAlignment.Center;
            txtCAJA3.DeselectAll();

            txtCAJA4.SelectAll();
            txtCAJA4.SelectionAlignment = HorizontalAlignment.Center;
            txtCAJA4.DeselectAll();

            txtCAJARAPIDA.SelectAll();
            txtCAJARAPIDA.SelectionAlignment = HorizontalAlignment.Center;
            txtCAJARAPIDA.DeselectAll();

            txtCLIENTESSALIENDO.SelectAll();
            txtCLIENTESSALIENDO.SelectionAlignment = HorizontalAlignment.Center;
            txtCLIENTESSALIENDO.DeselectAll();
        }
    }
}

