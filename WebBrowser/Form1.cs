using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Esto oculta los errores de script del navegador
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificamos si la tecla presionada fue "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                // Ejecutamos la navegación
                webBrowser1.Navigate(textBox1.Text);

                // Opcional: Esto evita que se escuche un "ding" de error de Windows al presionar Enter
                e.SuppressKeyPress = true;
            }
        }

    }
}
