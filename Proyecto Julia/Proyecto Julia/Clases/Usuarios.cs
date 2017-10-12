using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Clases
{
    public class Usuarios : IComparable
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string Nombre { get; private set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Constructor de la clase usuario
        /// </summary>
        /// <param name="nombre">Nombre de usuario</param>
        /// <param name="password">Contraseña</param>
        public Usuarios(string nombre, string password)
        {
            Nombre = nombre;
            Password = password;
        }

        /// <summary>
        /// Crea un objeto a partir de texto plano del archivo
        /// </summary>
        /// <param name="textoPlano">Texto con el formato especifico para crear el objeto</param>
        public Usuarios(string textoPlano)
        {
            string[] datos = textoPlano.Split('|');
            Nombre = datos[3];
            Password = datos[4];
        }

        /// <summary>
        /// Función que convierte la clase a un string.
        /// </summary>
        /// <returns>Devuelve un string con los campos de la clase</returns>
        public override string ToString()
        {
            return Nombre + "|" + Password;
        }

        /// <summary>
        /// Permite realizar la comparación entre dos objetos del mismo tipo.
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Retorna 0 si son iguales</returns>
        public int CompareTo(object obj)
        {
            if (obj is Usuarios)
            {
                if (((Usuarios) obj).Nombre == this.Nombre && ((Usuarios)obj).Password == this.Password)
                {
                    return 0;
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }
    }
}
