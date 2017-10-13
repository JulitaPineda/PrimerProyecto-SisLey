using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Julia.Estructuras;
using Proyecto_Julia.Clases;

namespace Proyecto_Julia
{
    static class Program
    {
        public static Pila<Prestamo> Prestamos = new Pila<Prestamo>("Prestamos");
        public static Cola<Prestamo> Solicitudes = new Cola<Prestamo>("Solucitudes"); 
        /// <summary>
        /// Listas donde se almacenan los datos del programa
        /// </summary>
        public static ListaDoblementeEnlazada<Leyes> Leyes = new ListaDoblementeEnlazada<Clases.Leyes>("Leyes", false);
        public static ListaDoblementeEnlazada<Reglamento> Reglamentos = new ListaDoblementeEnlazada<Reglamento>("Reglamentos", false);
        public static ListaDoblementeEnlazada<Usuarios> Usuarios = new ListaDoblementeEnlazada<Clases.Usuarios>("Usuarios", false);
        public static ListaDoblementeEnlazada<Grupo> Grupos = new ListaDoblementeEnlazada<Grupo>("Grupos", false);
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Usuarios.Agregar(new Clases.Usuarios("julita", "hola"));
                Usuarios.Guardar();
                string archivo = "c:\\sysley\\Leyes.list";
                // Carga una lista
                // Carga la lista de leyes
                StreamReader lector = new StreamReader(archivo);
                Leyes ley = null;
                Reglamento regla = null;
                string linea = lector.ReadLine();
                string[] separado = null;
                int i = 0;
                while (linea != "" && linea != null)
                {
                    separado = linea.Split('|');
                    // Se empieza a leer en el espacio 3 por que es donde empieza el objeto
                    regla = new Reglamento(separado[5], separado[6], Convert.ToInt32(separado[7]));
                    ley = new Clases.Leyes(separado[3], Convert.ToInt32(separado[4]), regla);
                    i = 8;
                    if (separado.Length > 8)
                    {
                        while (i < separado.Length)
                        {
                            ley.Reglamentos.Agregar(new Reglamento(separado[i], separado[i + 1], Convert.ToInt32(separado[i + 2])));
                            i += 3;
                        }
                        Leyes.Agregar(ley);
                    }
                    linea = lector.ReadLine();
                }
                lector.Close();
                Leyes.Guardar();
                archivo = "c:\\sysley\\Reglamentos.list";
                // Carga la lista de reglamentos
                lector = new StreamReader(archivo);
                linea = lector.ReadLine();
                while (linea != null)
                {
                    Reglamentos.Agregar(new Reglamento(linea));
                    linea = lector.ReadLine();
                }
                lector.Close();
                Reglamentos.Guardar();

                archivo = "c:\\sysley\\Usuarios.list";
                // Carga la lista de usuarios
                lector = new StreamReader(archivo);
                linea = lector.ReadLine();
                while (linea != "" && linea != null)
                {
                    Usuarios.Agregar(new Clases.Usuarios(linea));
                    linea = lector.ReadLine();
                }
                lector.Close();
                Usuarios.Guardar();

                archivo = "c:\\sysley\\Grupos.list";
                // Carga la lista de grupos
                lector = new StreamReader(archivo);
                linea = lector.ReadLine();
                while (linea != "" && linea != null)
                {
                    Grupos.Agregar(new Grupo(linea));
                    linea = lector.ReadLine();
                }
                lector.Close();
                Grupos.Guardar();
                lector = null;
                // Carga la pila de Prestamos
                archivo = "c:\\sysley\\Prestamos.pila";
                lector = new StreamReader(archivo);
                linea = lector.ReadLine();
                while (linea != "" && linea != null)
                {
                    string[] separados = linea.Split('|');

                    linea = lector.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.IO.File.Create("c:\\sysley\\Leyes.list");
                System.IO.File.Create("c:\\sysley\\Reglamentos.list");
                System.IO.File.Create("c:\\sysley\\Usuarios.list");
                System.IO.File.Create("c:\\sysley\\Grupos.list");
                System.IO.File.Create("c:\\sysley\\Prestamos.pila");
                System.IO.Directory.CreateDirectory(@"c:\sysley");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
