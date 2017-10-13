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
using Proyecto_Julia.Estructuras;

namespace Proyecto_Julia
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
                else
                {
                    if (actualizar)
                    {
                        Program.Reglamentos.Actualizar(posicionActualizar, new Reglamento(textBox2.Text, textBox3.Text, Convert.ToInt32(numericUpDown1.Value)));
                        button2.Text = "Guardar";
                        cargarReglamentos();
                        posicionActualizar = -1;
                        actualizar = false;
                    }
                    else
                    {
                        bool agregar = true;
                        for (int i = 0; i <= Program.Reglamentos.Cantidad; i++)
                        {
                            if (Program.Reglamentos.Buscar(i).Nombre == textBox2.Text)
                                agregar = false;
                        }
                        if (agregar)
                        {
                            Program.Reglamentos.Agregar(new Clases.Reglamento(textBox2.Text, textBox3.Text, Convert.ToInt32(numericUpDown1.Value)));
                        }
                        else
                        {
                            MessageBox.Show("El reglamento ya existe");
                        }
                        cargarReglamentos();
                        cargarReglamentosCombo();
                        cargarReglamentosCombo1();
                    }
                    Program.Reglamentos.Guardar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cargarReglamentos();
            cargarReglamentosCombo();
            cargarReglamentosCombo1();
            cargarLeyes();
            cargarLeyesCombo();
            cargarLeyesCombo1();
            cargarUsuarios();
            cargarUsuariosCombo();
            cargarUsuariosCombo1();
            cargarUsuariosCombo2();
            cargarGrupos();
            cargarGruposCombo();
            cargarGruposCombo1();
            cargarPrestamos();
            cargarSolicitudes();
        }

        /// <summary>
        /// Carga todos los reglamentos a un combobox para elegirlos y agregarlos a una ley
        /// </summary>
        private void cargarReglamentosCombo()
        {
            comboBox1.Items.Clear();
            Reglamento regla = null;
            for (int i = 0; i <= Program.Reglamentos.Cantidad; i++)
            {
                regla = Program.Reglamentos.Buscar(i);
                comboBox1.Items.Add(regla.Nombre);
            }
        }
        private void cargarReglamentosCombo1()
        {
            comboBox3.Items.Clear();
            Reglamento regla = null;
            for (int i = 0; i <= Program.Reglamentos.Cantidad; i++)
            {
                regla = Program.Reglamentos.Buscar(i);
                comboBox3.Items.Add(regla.Nombre);
            }
        }

        /// <summary>
        /// Muestra los reglamentos en un datagridview
        /// </summary>
        private void cargarReglamentos()
        {
            dataGridView1.Rows.Clear();
            Reglamento regla = null;
            for (int i = 0; i <= Program.Reglamentos.Cantidad; i++)
            {
                regla = Program.Reglamentos.Buscar(i);
                dataGridView1.Rows.Add(regla.Nombre, regla.Regla, regla.Copias);
            }
        }

        /// <summary>
        /// Muestra las leyes en un datagridview
        /// </summary>
        private void cargarLeyes()
        {
            dataGridView2.Rows.Clear();
            Leyes ley = null;
            for (int i = 0; i <= Program.Leyes.Cantidad; i++)
            {
                ley = Program.Leyes.Buscar(i);
                dataGridView2.Rows.Add(ley.Nombre, ley.Copias, ley.devolverReglamentos());
            }
        }

        /// <summary>
        /// Carga las leyes en un combobox
        /// </summary>
        private void cargarLeyesCombo()
        {
            comboBox2.Items.Clear();
            Leyes ley = null;
            for (int i = 0; i <= Program.Leyes.Cantidad; i++)
            {
                ley = Program.Leyes.Buscar(i);
                comboBox2.Items.Add(ley.Nombre);
            }
        }
        private void cargarLeyesCombo1()
        {
            comboBox7.Items.Clear();
            Leyes ley = null;
            for (int i = 0; i <= Program.Leyes.Cantidad; i++)
            {
                ley = Program.Leyes.Buscar(i);
                comboBox7.Items.Add(ley.Nombre);
            }
        }

        /// <summary>
        /// Carga los usuarios en un datagridview
        /// </summary>
        private void cargarUsuarios()
        {
            dataGridView3.Rows.Clear();
            Usuarios user = null;
            for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
            {
                user = Program.Usuarios.Buscar(i);
                dataGridView3.Rows.Add(user.Nombre);
            }
        }

        /// <summary>
        /// Carga los usuarios a un combobox
        /// </summary>
        private void cargarUsuariosCombo()
        {
            comboBox4.Items.Clear();
            Usuarios user = null;
            for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
            {
                user = Program.Usuarios.Buscar(i);
                comboBox4.Items.Add(user.Nombre);
            }
        }
        private void cargarUsuariosCombo1()
        {
            comboBox6.Items.Clear();
            Usuarios user = null;
            for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
            {
                user = Program.Usuarios.Buscar(i);
                comboBox6.Items.Add(user.Nombre);
            }
        }
        private void cargarUsuariosCombo2()
        {
            comboBox9.Items.Clear();
            Usuarios user = null;
            for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
            {
                user = Program.Usuarios.Buscar(i);
                comboBox9.Items.Add(user.Nombre);
            }
        }

        bool actualizar = false;
        int posicionActualizar = -1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button2.Text = "Actualizar";
                Reglamento regla = null;
                for (int i = 0; i <=  Program.Reglamentos.Cantidad; i++)
                {
                    regla = Program.Reglamentos.Buscar(i);
                    if (regla.Nombre == textBox1.Text)
                    {
                        posicionActualizar = i;
                        actualizar = true;
                        i = Program.Reglamentos.Cantidad + 1;
                    }
                }
                if (actualizar)
                {
                    textBox2.Text = regla.Nombre;
                    textBox3.Text = regla.Regla;
                    numericUpDown1.Value = Convert.ToDecimal(regla.Copias);
                }
                else
                {
                    MessageBox.Show("No se encontró el registro.");
                }
            }
            else
            {
                MessageBox.Show("Debe llenar el campo de busqueda");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "" || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe llenar todos los campos.");
                }
                else
                {
                    if (actualizar)
                    {
                        ListaDoblementeEnlazada<Reglamento> reglamentos = Program.Leyes.Buscar(posicionActualizar).Reglamentos;
                        Program.Leyes.Actualizar(posicionActualizar, new Leyes(textBox5.Text, Convert.ToInt32(numericUpDown2.Value), reglamentos));
                        button3.Text = "Guardar";
                        posicionActualizar = -1;
                        actualizar = false;

                    }
                    else
                    {
                        bool agregar = true;
                        Leyes ley = null;
                        for (int i = 0; i <= Program.Leyes.Cantidad; i++)
                        {
                            ley = Program.Leyes.Buscar(i);
                            if (ley.Nombre == textBox5.Text)
                                agregar = false;
                        }
                        if (agregar)
                        {
                            Program.Leyes.Agregar(new Leyes(textBox5.Text, Convert.ToInt32(numericUpDown2.Value),
                                Program.Reglamentos.Buscar(comboBox1.SelectedIndex)));
                        }
                        else
                        {
                            MessageBox.Show("La ley ya existe");
                        }
                    }
                    cargarLeyes();
                    cargarLeyesCombo();
                    cargarLeyesCombo1();
                    Program.Leyes.Guardar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                button3.Text = "Actualizar";
                Leyes ley = null;
                for (int i = 0; i <= Program.Leyes.Cantidad; i++)
                {
                    ley = Program.Leyes.Buscar(i);
                    if (ley.Nombre == textBox4.Text)
                    {
                        actualizar = true;
                        posicionActualizar = i;
                        i = Program.Leyes.Cantidad + 1;
                    }
                }
                if (actualizar)
                {
                    textBox5.Text = ley.Nombre;
                    numericUpDown2.Value = Convert.ToDecimal(ley.Copias);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1)
            {
                Reglamento reglamento = null;
                for (int i = 0; i <= Program.Reglamentos.Cantidad; i++)
                {
                    reglamento = Program.Reglamentos.Buscar(i);
                    if (reglamento.Nombre == comboBox3.SelectedItem.ToString())
                    {
                        i = Program.Reglamentos.Cantidad + 1;
                    }
                }
                for (int i = 0; i <= Program.Leyes.Cantidad; i++)
                {
                    if (Program.Leyes.Buscar(i).Nombre == comboBox2.SelectedItem.ToString())
                    {
                        Program.Leyes.Buscar(i).Reglamentos.Agregar(reglamento);
                    }
                }
                cargarLeyes();
                Program.Leyes.Guardar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ley y un reglamento");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text != "" || textBox8.Text != "")
                {
                    if (actualizar)
                    {
                        Usuarios user = Program.Usuarios.Buscar(posicionActualizar);
                        string pass = user.Password;
                        Program.Usuarios.Actualizar(posicionActualizar, new Usuarios(textBox7.Text, pass));
                        button6.Text = "Guardar";
                        actualizar = false;
                        posicionActualizar = -1;
                    }
                    else
                    {
                        Usuarios user = null;
                        bool agregar = true;
                        for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
                        {
                            user = Program.Usuarios.Buscar(i);
                            if (user.Nombre == textBox7.Text)
                            {
                                agregar = false;
                                i = Program.Usuarios.Cantidad + 1;
                            }
                        }
                        if (!agregar)
                        {
                            MessageBox.Show("El usuario ya existe");
                        }
                        else
                        {
                            Program.Usuarios.Agregar(new Usuarios(textBox7.Text, textBox8.Text));
                        }
                    }
                    cargarUsuarios();
                    cargarUsuariosCombo();
                    cargarUsuariosCombo1();
                    cargarUsuariosCombo2();
                    Program.Usuarios.Guardar();
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Carga los grupos en un datagridview
        /// </summary>
        private void cargarGrupos()
        {
            dataGridView4.Rows.Clear();
            Grupo grupo = null;
            for (int i = 0; i <= Program.Grupos.Cantidad; i++)
            {
                grupo = Program.Grupos.Buscar(i);
                dataGridView4.Rows.Add(grupo.Nombre, grupo.Parlamentario.Nombre, grupo.devolverUsuarios());
            }
        }

        /// <summary>
        /// Carga los grupos en un combobox
        /// </summary>
        private void cargarGruposCombo()
        {
            comboBox5.Items.Clear();
            Grupo grupo = null;
            for (int i = 0; i <= Program.Grupos.Cantidad; i++)
            {
                grupo = Program.Grupos.Buscar(i);
                comboBox5.Items.Add(grupo.Nombre);
            }
        }
        private void cargarGruposCombo1()
        {
            comboBox8.Items.Clear();
            Grupo grupo = null;
            for (int i = 0; i <= Program.Grupos.Cantidad; i++)
            {
                grupo = Program.Grupos.Buscar(i);
                comboBox8.Items.Add(grupo.Nombre);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                Usuarios user = null;
                bool encontrado = false;
                for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
                {
                    user = Program.Usuarios.Buscar(i);
                    if (user.Nombre == textBox6.Text)
                    {
                        encontrado = true;
                        posicionActualizar = i;
                        actualizar = true;
                        i = Program.Usuarios.Cantidad + 1;
                    }
                }
                if (encontrado)
                {
                    button6.Text = "Actualizar";
                    textBox7.Text = user.Nombre;
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text == "" || comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
                else
                {
                    if (actualizar)
                    {
                        Usuarios parla = null;
                        for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
                        {
                            parla = Program.Usuarios.Buscar(i);
                            if (parla.Nombre == comboBox4.SelectedItem.ToString())
                            {
                                i = Program.Usuarios.Cantidad + 1;
                            }
                        }
                        Program.Grupos.Actualizar(posicionActualizar, new Grupo(parla, textBox10.Text));
                        button9.Text = "Guardar";
                        actualizar = false;
                        posicionActualizar = -1;
                    }
                    else
                    {
                        Usuarios parlamentario = null;
                        for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
                        {
                            parlamentario = Program.Usuarios.Buscar(i);
                            if (parlamentario.Nombre == comboBox4.SelectedItem.ToString())
                            {
                                i = Program.Usuarios.Cantidad + 1;
                            }
                        }
                        bool encontrado = false;
                        for (int i = 0; i <= Program.Grupos.Cantidad; i++)
                        {
                            if (Program.Grupos.Buscar(i).Nombre == textBox10.Text)
                            {
                                encontrado = true;
                                i = Program.Grupos.Cantidad + 1;
                            }
                        }
                        if (encontrado)
                        {
                            MessageBox.Show("El grupo ya existe");
                        }
                        else
                        {
                            Program.Grupos.Agregar(new Grupo(parlamentario, textBox10.Text));
                        }
                    }
                    cargarGrupos();
                    cargarGruposCombo();
                    cargarGruposCombo1();
                    Program.Grupos.Guardar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                Grupo grupo = null;
                bool encontrado = false;
                for (int i = 0; i <= Program.Grupos.Cantidad; i++)
                {
                    grupo = Program.Grupos.Buscar(i);
                    if (grupo.Nombre == textBox9.Text)
                    {
                        encontrado = true;
                        actualizar = true;
                        posicionActualizar = i;
                        i = Program.Grupos.Cantidad;
                    }
                }
                if (!encontrado)
                {
                    MessageBox.Show("El grupo no existe");
                }
                else
                {
                    button9.Text = "Actualizar";
                    textBox10.Text = grupo.Nombre;
                    comboBox4.SelectedItem = grupo.Parlamentario.Nombre;
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un grupo para buscar");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex != -1 && comboBox6.SelectedIndex != -1)
            {
                Usuarios user = null;
                for (int i = 0; i <= Program.Usuarios.Cantidad; i++)
                {
                    user = Program.Usuarios.Buscar(i);
                    if (user.Nombre == comboBox6.SelectedItem.ToString())
                    {
                        i = Program.Usuarios.Cantidad + 1;
                    }
                }
                for (int i = 0; i <= Program.Grupos.Cantidad; i++)
                {
                    if (Program.Grupos.Buscar(i).Nombre == comboBox5.SelectedItem.ToString())
                    {
                        Program.Grupos.Buscar(i).agregarUsuario(user);
                        i = Program.Grupos.Cantidad + 1;
                    }
                }
                cargarGrupos();
                Program.Grupos.Guardar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar grupo y usuario");
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Grupos.Guardar();
            Program.Leyes.Guardar();
            Program.Reglamentos.Guardar();
            Program.Usuarios.Guardar();
            Application.Exit();
        }

        private void cargarPrestamos()
        {
            Prestamo prestamos = null;
            dataGridView5.Rows.Clear();
            for (int i = 0; i <= Program.Prestamos.Cantidad; i++)
            {
                prestamos = Program.Prestamos.Buscar(i);
                dataGridView5.Rows.Add(prestamos.Ley.Nombre, prestamos.GrupoPrestado.Nombre, prestamos.Encargado.Nombre);
            }
        }

        private void cargarSolicitudes()
        {
            Prestamo solicitud = null;
            dataGridView6.Rows.Clear();
            for (int i = 0; i <= Program.Solicitudes.Cantidad; i++)
            {
                solicitud = Program.Solicitudes.Buscar(i);
                dataGridView6.Rows.Add(solicitud.Ley.Nombre, solicitud.GrupoPrestado.Nombre, solicitud.Encargado.Nombre);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Leyes ley = null;
            Grupo grupo = null;
            Usuarios user = null;
            for (int i = 0; i <= Program.Leyes.Cantidad; i++)
            {
                ley = Program.Leyes.Buscar(i); 
                if (ley.Nombre == comboBox7.SelectedItem.ToString())
                {
                    i = Program.Leyes.Cantidad + 1;
                }
            }
            for (int i = 0; i <= Program.Grupos.Cantidad; i++)
            {
                grupo = Program.Grupos.Buscar(i);
                if (grupo.Nombre == comboBox8.SelectedItem.ToString())
                {
                    i = Program.Grupos.Cantidad + 1;
                }
            }
            if (comboBox9.SelectedItem.ToString() != grupo.Parlamentario.Nombre)
            {
                for (int i = 0; i < grupo.Usuarios.Cantidad; i++)
                {
                    user = grupo.Usuarios.Buscar(i);
                    if (user.Nombre == comboBox9.SelectedItem.ToString())
                    {
                        i = grupo.Usuarios.Cantidad + 1;
                    }
                }
            }
            else
            {
                user = grupo.Parlamentario;
            }
            if (ley.Prestamos >= ley.Copias)
            {
                ley.Prestamos++;
                MessageBox.Show("Se hará una solicitud para prestar la ley.");
                Program.Solicitudes.Encolar(new Prestamo(grupo, 1, user, ley));
                Program.Solicitudes.Guardar();
            }
            else
            {
                ley.Prestamos++;
                Program.Prestamos.Apilar(new Prestamo(grupo, 1, user, ley));
                Program.Prestamos.Guardar();
            }
            cargarPrestamos();
            cargarSolicitudes();
        }
    }
}
