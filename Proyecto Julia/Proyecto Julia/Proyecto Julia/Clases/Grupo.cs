using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Clases
{
    public class Grupo : IComparable
    {
        /// <summary>
        /// Nombre del grupo
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Parlamentario del grupo
        /// </summary>
        public Usuarios Parlamentario { get; set; }

        /// <summary>
        /// Lista de usuarios del grupo
        /// </summary>
        public Estructuras.ListaDoblementeEnlazada<Usuarios> Usuarios { get; private set; }

        /// <summary>
        /// Cantidad de asesores del grupo
        /// </summary>
        private int Asesores { get; set; }

        /// <summary>
        /// Constructor del grupo
        /// </summary>
        /// <param name="parlamentario">Recibe el nombre del parlamentario</param>
        /// <param name="nombre">Recibe el nombre del grupo</param>
        public Grupo(Usuarios parlamentario, string nombre)
        {
            Parlamentario = parlamentario;
            Nombre = nombre;
            Usuarios = new Estructuras.ListaDoblementeEnlazada<Clases.Usuarios>(Nombre, false);
            Asesores = 0;
        }

        /// <summary>
        /// Constructor del grupo
        /// </summary>
        /// <param name="textoPlano">Recibe todos los datos como texto plano de un archivo</param>
        public Grupo(string textoPlano)
        {
            string[] datos = textoPlano.Split('|');
            Nombre = datos[3];
            Parlamentario = new Clases.Usuarios(datos[4], datos[5]);
            Usuarios = new Estructuras.ListaDoblementeEnlazada<Clases.Usuarios>("Grupos", false);
            for (int i = 6; i < datos.Length; i = i + 2)
            {
                Usuarios.Agregar(new Clases.Usuarios(datos[i], datos[i + 1]));
                Asesores++;
            }
        }

        /// <summary>
        /// Agrega un nuevo usuario al grupo
        /// </summary>
        /// <param name="usuario">Objeto usuario que se desea agregar</param>
        public void agregarUsuario(Usuarios usuario)
        {
            if (Asesores == 8)
                throw new Exception("Se superó el maximo de asesores.");
            Asesores++;
            Usuarios.Agregar(usuario);
        }

        /// <summary>
        /// Elimina un usuario del grupo
        /// </summary>
        /// <param name="lugar">Recibe la posición en la que se encuentra el usuario</param>
        public void eliminarUsuario(int lugar)
        {
            if (Asesores == 0)
                throw new Exception("Ya no hay asesores que se puedan eliminar.");
            Asesores--;
            Usuarios.Eliminar(lugar);
        }

        /// <summary>
        /// Genera un string con todos los asesores relacionados con este grupo
        /// </summary>
        /// <returns>String con los datos separados por coma</returns>
        public string devolverUsuarios()
        {
            string retorno = "";
            for (int i = 0; i <= Usuarios.Cantidad; i++)
            {
                retorno += Usuarios.Buscar(i).Nombre;
            }
            return retorno;
        }

        /// <summary>
        /// Convierte a string el objeto
        /// </summary>
        /// <returns>Devuelve un string del objeto</returns>
        public override string ToString()
        {
            string retorno = Nombre + "|" + Parlamentario.ToString() + "|" + Parlamentario.ToString();
            for (int i = 0; i <= Usuarios.Cantidad; i++)
            {
                if (i == Usuarios.Cantidad - 1)
                    retorno += Usuarios.Buscar(i).ToString();
                else
                    retorno += Usuarios.Buscar(i).ToString() + "|";
            }
            return retorno;
        }

        /// <summary>
        /// Permite realizar la comparación entre dos objetos del mismo tipo.
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Retorna 0 si son iguales</returns>
        public int CompareTo(object obj)
        {
            if (obj is Grupo)
            {
                if (((Grupo) obj).Nombre == this.Nombre && ((Grupo) obj).Usuarios.Cantidad == Usuarios.Cantidad)
                {
                    for (int i = 0; i < Asesores; i++)
                    {
                        if (((Grupo)obj).Usuarios.Buscar(i).CompareTo(Usuarios.Buscar(i)) != 0)
                        {
                            return -1;
                        }
                    }
                    return 0;
                }
            }
            return -1;
        }
    }
}
