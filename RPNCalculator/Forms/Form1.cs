using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stack;

namespace Forms
{
    public partial class Form1 : Form
    {
        ArrayStack<double> stack = new ArrayStack<double>(4);
        double num = 0;
        double num1, num2;
        bool isDotPressed = false;
        bool isMinusPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += "0";
        }

        private void btnPUNTO_Click(object sender, EventArgs e)
        {
            if (!isDotPressed)
            {
                txtINPUT.Text += ".";
                isDotPressed = true;
            }
        }

        private void btnSPACE_Click(object sender, EventArgs e)
        {
            txtINPUT.Text += " ";
            isDotPressed = false;
            isMinusPressed = false;
        }

        private void btnBACK_Click(object sender, EventArgs e)
        {
            if (txtINPUT.Text.Length == 1)
            {
                txtINPUT.Text = txtINPUT.Text.Remove(txtINPUT.Text.Length - 1);
                isDotPressed = false;
                isMinusPressed = false;
            }
            else if (txtINPUT.Text != "") //Comprobar que en el input haya algo escrito
            {
                //Elimino el último caracter de la cadena
                txtINPUT.Text = txtINPUT.Text.Remove( txtINPUT.Text.Length - 1 );
                isDotPressed = true;
                isMinusPressed = true;
            }
        }

        private void btnENTER_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if (numData.Length > 1) //Puso múltiples números
            {
                foreach(string element in numData)
                {
                    try
                    {
                        num = Convert.ToDouble(element);
                        stack.Push(num);

                        PrintArrayStack();
                    } 
                    catch (Exception error)
                    {
                        MessageBox.Show("Caracter no válido para el stack", "Error");
                    }
                }
            } else if (txtINPUT.Text.Trim() != "") //Verifico si hay numeros en la pantalla y no solo espacios en blanco
            {
                try
                {
                    num = Convert.ToDouble(txtINPUT.Text);
                    stack.Push(num);

                    PrintArrayStack();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Caracter no válido para el stack", "Error");
                }
            }

            txtINPUT.Text = "";
            isDotPressed = false;
            isMinusPressed = false;
        }

        private void PrintArrayStack() //Sirve para mostrar en la pantalla el estado actual de la pila
        {
            string data = "";

            for (int i = 0; i < stack.Size; ++i) //Recolectando los datos de la pila
            {
                data += $"{stack.Size - i}: {stack[i]}\n";
            }

            txtPANTALLA.Text = data;
        }

        private void btnSIGNO_Click(object sender, EventArgs e)
        {
            if (!isDotPressed && !isMinusPressed)
            {
                txtINPUT.Text += "-";
                isMinusPressed = true;
            }
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            if (txtINPUT.Text.Trim() == "" && stack.Size > 0)
            {
                //Procedo a borrar la pila
                for(int i = 0; i < stack.Size + 1; i++)
                {
                    stack.Pop();
                }
                    
                PrintArrayStack();
                txtINPUT.Text = "";
            } 
            else if (stack.Size == 0)
            {
                MessageBox.Show("No tiene datos en la pila a borrar");
            } 
            else
            {
                MessageBox.Show("Está intentando borrar la Pila cuando tiene datos en input");
            }
        }

        private void btnDUP_Click(object sender, EventArgs e)
        {
            if (txtINPUT.Text.Trim() == "" && stack.Size > 0)
            {
                //Procedo a copiar el ultimo elemento ingresado a la pila
                stack.Push( stack.Peek() );

                PrintArrayStack();
                txtINPUT.Text = "";
            }
            else if (stack.Size == 0)
            {
                MessageBox.Show("No tiene datos en la pila a copiar");
            }
            else
            {
                MessageBox.Show("Está intentando copiar un dato de la Pila cuando tiene datos en input");
            }
        }

        private void btnSIN_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if (txtINPUT.Text.Trim() == "" && stack.Size > 0)
            {
                stack.Push( Math.Sin( stack.Pop() ) ); //Retorno el seno del ultimo del stack
            } 
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede ingresar el seno de un número si tiene más de un elemento\nen input");
            } 
            else if (txtINPUT.Text.Trim() != "")
            {
                try
                {
                    num = Convert.ToDouble( txtINPUT.Text );
                    num = ConvertToRadians(num);
                    stack.Push(Math.Sin(num)); //Meto a la pila el seno del utimo ingresado
                } 
                catch (Exception error)
                {
                    MessageBox.Show("Caracter no válido para sacar seno", "Error");
                }
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnCOS_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if (txtINPUT.Text.Trim() == "" && stack.Size > 0)
            {
                stack.Push(Math.Cos(stack.Pop())); //Retorno el seno del ultimo del stack
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede ingresar el coseno de un número si tiene más de un elemento\nen input");
            }
            else if (txtINPUT.Text.Trim() != "")
            {
                try
                {
                    num = Convert.ToDouble(txtINPUT.Text);
                    num = ConvertToRadians(num);
                    stack.Push(Math.Cos(num)); //Meto a la pila el seno del utimo ingresado
                }
                catch (Exception error)
                {
                    MessageBox.Show("Caracter no válido para sacar coseno", "Error");
                }
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }  

        private void btnTAN_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if (txtINPUT.Text.Trim() == "" && stack.Size > 0)
            {
                stack.Push(Math.Tan(stack.Pop())); //Retorno el seno del ultimo del stack
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede ingresar el tangente de un número si tiene más de un elemento\nen input");
            }
            else if (txtINPUT.Text.Trim() != "")
            {
                try
                {
                    num = Convert.ToDouble(txtINPUT.Text);
                    num = ConvertToRadians(num);
                    stack.Push(Math.Tan(num)); //Meto a la pila el seno del utimo ingresado
                }
                catch (Exception error)
                {
                    MessageBox.Show("Caracter no válido para sacar tangente", "Error");
                }
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnPLUS_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if ( (numData.Length == 1 && numData[0] != "") && stack.Size >= 1 ) //Puso un numero nada más en input
            {
                try
                {
                    num2 = Convert.ToDouble( txtINPUT.Text );
                    num1 = stack.Pop();

                    stack.Push( num1 + num2 );
                }
                catch (Exception error)
                {
                    MessageBox.Show("Lo que ingresó no es un número", "Error");
                }
            } 
            else if (stack.Size >= 2 && txtINPUT.Text.Trim() == "") //Verifico primero si hay dos o más elementos en el stack
            {
                num2 = stack.Pop();
                num1 = stack.Pop();

                stack.Push( num1 + num2 );
            } 
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede hacer la operación con múltiples datos ingresados");
            }
            else
            {
                MessageBox.Show("Intente ingresar datos a la pila o al input");
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnMINUS_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if ((numData.Length == 1 && numData[0] != "") && stack.Size >= 1) //Puso un numero nada más en input
            {
                try
                {
                    num2 = Convert.ToDouble(txtINPUT.Text);
                    num1 = stack.Pop();

                    stack.Push(num1 - num2);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Lo que ingresó no es un número", "Error");
                }
            }
            else if (stack.Size >= 2 && txtINPUT.Text.Trim() == "") //Verifico primero si hay dos o más elementos en el stack
            {
                num2 = stack.Pop();
                num1 = stack.Pop();

                stack.Push(num1 - num2);
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede hacer la operación con múltiples datos ingresados");
            }
            else
            {
                MessageBox.Show("Intente ingresar datos a la pila o al input");
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnTIMES_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if ((numData.Length == 1 && numData[0] != "") && stack.Size >= 1) //Puso un numero nada más en input
            {
                try
                {
                    num2 = Convert.ToDouble(txtINPUT.Text);
                    num1 = stack.Pop();

                    stack.Push(num1 * num2);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Lo que ingresó no es un número", "Error");
                }
            }
            else if (stack.Size >= 2 && txtINPUT.Text.Trim() == "") //Verifico primero si hay dos o más elementos en el stack
            {
                num2 = stack.Pop();
                num1 = stack.Pop();

                stack.Push(num1 * num2);
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede hacer la operación con múltiples datos ingresados");
            }
            else
            {
                MessageBox.Show("Intente ingresar datos a la pila o al input");
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnDIVIDED_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            //Verificar que el segundo número no sea un 0

            if ((numData.Length == 1 && numData[0] != "") && stack.Size >= 1) //Puso un numero nada más en input
            {
                if (numData[0] == "0")
                {
                    MessageBox.Show("No se puede hacer división sobre 0");
                    txtINPUT.Text = "";
                    return;
                }

                try
                {
                    num2 = Convert.ToDouble(txtINPUT.Text);
                    num1 = stack.Pop();

                    stack.Push(num1 / num2);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Lo que ingresó no es un número", "Error");
                }
            }
            else if (stack.Size >= 2 && txtINPUT.Text.Trim() == "") //Verifico primero si hay dos o más elementos en el stack
            {
                if (stack.Peek() == 0)
                {
                    MessageBox.Show("No se puede hacer división sobre 0");
                    txtINPUT.Text = "";
                    return;
                }

                num2 = stack.Pop();
                num1 = stack.Pop();

                stack.Push(num1 / num2);
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede hacer la operación con múltiples datos ingresados");
            }
            else
            {
                MessageBox.Show("Intente ingresar datos a la pila o al input");
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnPOW_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if ((numData.Length == 1 && numData[0] != "") && stack.Size >= 1) //Puso un numero nada más en input
            {
                try
                {
                    num2 = Convert.ToDouble(txtINPUT.Text);
                    num1 = stack.Pop();

                    stack.Push( Math.Pow(num1, num2) );
                }
                catch (Exception error)
                {
                    MessageBox.Show("Lo que ingresó no es un número", "Error");
                }
            }
            else if (stack.Size >= 2 && txtINPUT.Text.Trim() == "") //Verifico primero si hay dos o más elementos en el stack
            {
                num2 = stack.Pop();
                num1 = stack.Pop();

                stack.Push( Math.Pow(num1, num2) );
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede hacer la operación con múltiples datos ingresados");
            }
            else
            {
                MessageBox.Show("Intente ingresar datos a la pila o al input");
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnSQRT_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if (stack.Size > 1)
            {
                if (stack[stack.Size - 2] < 0)
                {
                    MessageBox.Show("Número negativo en raíz cuadrada");
                    return;
                }
            }

            if ((numData.Length == 1 && numData[0] != "") && stack.Size >= 1) //Puso un numero nada más en input
            {
                try
                {
                    if (stack.Peek() < 0)
                    {
                        MessageBox.Show("Número negativo en raíz cuadrada");
                        return;
                    }

                    num2 = Convert.ToDouble(txtINPUT.Text);
                    num1 = stack.Pop();

                    stack.Push(Math.Pow(num1, 1 / num2));
                }
                catch (Exception error)
                {
                    MessageBox.Show("Lo que ingresó no es un número", "Error");
                }
            }
            else if (stack.Size >= 2 && txtINPUT.Text.Trim() == "") //Verifico primero si hay dos o más elementos en el stack
            {
                num2 = stack.Pop();
                num1 = stack.Pop();

                stack.Push(Math.Pow(num1, 1 / num2));
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No puede hacer la operación con múltiples datos ingresados");
            }
            else
            {
                MessageBox.Show("Intente ingresar datos a la pila o al input");
            }

            PrintArrayStack();
            txtINPUT.Text = "";
        }

        private void btnFRACCION_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if ((numData.Length == 1 && numData[0] != "") && numData[0] == "0")
            {
                MessageBox.Show("No se puede hacer división sobre 0");
                txtINPUT.Text = "";
                return;
            }
            else if ( numData.Length == 1 && numData[0] != "" )
            {
                try
                {
                    num = 1 / Convert.ToDouble( txtINPUT.Text );
                    txtINPUT.Text = num.ToString();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Caracter no válido para sacarle fracción", "Error");
                }
            } 
            else if (numData.Length > 1)
            {
                MessageBox.Show("No es posible sacar fracción habiendo múltiples datos en input");
            }
        }

        private void btnCUADRADO_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if ((numData.Length == 1 && numData[0] != "") && numData[0] == "0")
            {
                MessageBox.Show("No se puede hacer división sobre 0");
                txtINPUT.Text = "";
                return;
            }
            else if (numData.Length == 1 && numData[0] != "")
            {
                try
                {
                    num = Math.Pow( Convert.ToDouble(txtINPUT.Text), 2 );
                    txtINPUT.Text = num.ToString();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Caracter no válido para sacarle fracción", "Error");
                }
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No es posible sacar fracción habiendo múltiples datos en input");
            }
        }

        private void btnRAIZ_Click(object sender, EventArgs e)
        {
            string[] numData = txtINPUT.Text.Split();

            if ((numData.Length == 1 && numData[0] != "") && numData[0] == "0")
            {
                MessageBox.Show("No se puede hacer división sobre 0");
                txtINPUT.Text = "";
                return;
            }
            else if (numData.Length == 1 && numData[0] != "")
            {
                try
                {
                    num = Math.Sqrt(Convert.ToDouble(txtINPUT.Text));
                    txtINPUT.Text = num.ToString();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Caracter no válido para sacarle fracción", "Error");
                }
            }
            else if (numData.Length > 1)
            {
                MessageBox.Show("No es posible sacar fracción habiendo múltiples datos en input");
            }
        }

        private void txtINPUT_TextChanged(object sender, EventArgs e)
        {
        }

        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}
