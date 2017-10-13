using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Julia.Clases;

namespace Proyecto_Julia
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(textBox1.Text, textBox2.Text);
            bool encontrado = false;
            for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
            {
                if (usuario.CompareTo(Program.Usuarios.Buscar(i)) == 0)
                {
                    Form3 form = new Form3();
                    form.Show();
                    this.Close();
                    encontrado = true;
                }
            }
            if (!encontrado)
                MessageBox.Show("No se encontró el usuario indicado");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
