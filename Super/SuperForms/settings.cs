using Super;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperForms
{
    public partial class Settings : Form
    {
        Form1 mainForm = new Form1();
        System.Timers.Timer timer;
        int MAX_NUM_CLIENTS;
        int MAX_NUM_PRODUCTS;
        int MAX_CLIENT_DELAY;
        int EXPRESS_LANE_MAX_PRODUCTS;
        Caja[] cajas = new Caja[5];

        public Form1 MainForm { get => mainForm; set => mainForm = value; }

        public Settings(int MAX_NUM_CLIENTS, int MAX_NUM_PRODUCTS, int MAX_CLIENT_DELAY, int EXPRESS_LANE_MAX_PRODUCTS, System.Timers.Timer timer, Caja[] cajas)
        {
            this.MAX_NUM_CLIENTS = MAX_NUM_CLIENTS;
            this.MAX_NUM_PRODUCTS = MAX_NUM_PRODUCTS;
            this.MAX_CLIENT_DELAY = MAX_CLIENT_DELAY;
            this.EXPRESS_LANE_MAX_PRODUCTS = EXPRESS_LANE_MAX_PRODUCTS;
            this.timer = timer;
            this.cajas = cajas;

            InitializeComponent();

            upDownMAX_NUM_CLIENTS.Value = this.MAX_NUM_CLIENTS;
            upDownMAX_NUM_PRODUCTS.Value = this.MAX_NUM_PRODUCTS;
            upDownMAX_CLIENT_DELAY.Value = this.MAX_CLIENT_DELAY;
            upDownEXPRESS_LANE_MAX_PRODUCTS.Value = this.EXPRESS_LANE_MAX_PRODUCTS;
            upDownSIMULATION_STEP_TIME.Value = Convert.ToInt32(this.timer.Interval);

            //Checkout de las cajas
            upDownCAJA1_CHECKOUT.Value = this.cajas[0]._CHECKOUT_NUM_OF_PRODUCTS;
            upDownCAJA2_CHECKOUT.Value = this.cajas[1]._CHECKOUT_NUM_OF_PRODUCTS;
            upDownCAJA3_CHECKOUT.Value = this.cajas[2]._CHECKOUT_NUM_OF_PRODUCTS;
            upDownCAJA4_CHECKOUT.Value = this.cajas[3]._CHECKOUT_NUM_OF_PRODUCTS;
            upDownCAJA_R_CHECKOUT.Value = this.cajas[4]._CHECKOUT_NUM_OF_PRODUCTS;
        }

        private void btnGUARDAR_Click(object sender, EventArgs e)
        {
            mainForm.MAX_NUM_CLIENTS = Convert.ToInt32(upDownMAX_NUM_CLIENTS.Value);
            mainForm.MAX_NUM_PRODUCTS = Convert.ToInt32(upDownMAX_NUM_PRODUCTS.Value);
            mainForm.MAX_CLIENT_DELAY = Convert.ToInt32(upDownMAX_CLIENT_DELAY.Value);
            mainForm.EXPRESS_LANE_MAX_PRODUCTS = Convert.ToInt32(upDownEXPRESS_LANE_MAX_PRODUCTS.Value);
            mainForm.Timer.Interval = Convert.ToInt32(upDownSIMULATION_STEP_TIME.Value);

            //Guardo los checkouts
            mainForm.Cajas[0]._CHECKOUT_NUM_OF_PRODUCTS = Convert.ToInt32(upDownCAJA1_CHECKOUT.Value);
            mainForm.Cajas[1]._CHECKOUT_NUM_OF_PRODUCTS = Convert.ToInt32(upDownCAJA2_CHECKOUT.Value);
            mainForm.Cajas[2]._CHECKOUT_NUM_OF_PRODUCTS = Convert.ToInt32(upDownCAJA3_CHECKOUT.Value);
            mainForm.Cajas[3]._CHECKOUT_NUM_OF_PRODUCTS = Convert.ToInt32(upDownCAJA4_CHECKOUT.Value);
            mainForm.Cajas[4]._CHECKOUT_NUM_OF_PRODUCTS = Convert.ToInt32(upDownCAJA_R_CHECKOUT.Value);

            MessageBox.Show("Nuevos valores guardados");
        }

        private void btnCERRAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
