using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Clases
{
    public class Reglamento : IComparable
    {
        /// <summary>
        /// Cantidad de copias de la regla
        /// </summary>
        public int Copias { get; private set; }
        /// <summary>
        /// Nombre del reglamento
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Regla que define este reglamento
        /// </summary>
        public string Regla { get; private set; }

        /// <summary>
        /// Crea un objeto Reglamento
        /// </summary>
        /// <param name="nombre">Nombre de la regla</param>
        /// <param name="regla">Regla que define el reglamento</param>
        public Reglamento(string nombre, string regla, int copias)
        {
            if (copias > 5)
                throw new Exception("No se pueden crear más de 5 copias del reglamento.");
            Copias = copias;
            Nombre = nombre;
            Regla = regla;
        }

        /// <summary>
        /// Agrega una cantidad especifica de copias al reglamento
        /// </summary>
        /// <param name="cantidad">Cantidad de copias que se desea agregar</param>
        public void agregarCopia(int cantidad)
        {
            if (cantidad + Copias > 5)
                throw new Exception("No se pueden crear más de 5 copias del reglamento.");
            Copias += cantidad;
        }

        /// <summary>
        /// Elimina una cantidad especifica de copias al reglamento
        /// </summary>
        /// <param name="cantidad">Cantidad de copias que desea eliminar</param>
        public void eliminarCopia(int cantidad)
        {
            if (Copias - cantidad < 1)
                throw new Exception("No se pueden eliminar más de " + (4 - Copias) + " copias");
            Copias -= cantidad;
        }

        /// <summary>
        /// Crea un objeto Reglamento a partir de texto de un archivo.
        /// </summary>
        /// <param name="textoPlano">Texto del archivo</param>
        public Reglamento(string textoPlano)
        {
            string[] datos = textoPlano.Split('|');
            Nombre = datos[3];
            Regla = datos[4];
            Copias = Convert.ToInt32(datos[5]);
        }

        /// <summary>
        /// Devuelve el objeto en un string
        /// </summary>
        /// <returns>String con el objeto</returns>
        public override string ToString()
        {
            return Nombre + "|" + Regla + "|" + Copias;
        }
        /// <summary>
        /// Permite realizar la comparación entre dos objetos del mismo tipo.
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Retorna 0 si son iguales</returns>
        public int CompareTo(object obj)
        {
            if (obj is Reglamento)
            {
                if (((Reglamento) obj).Nombre == this.Nombre && ((Reglamento)obj).Regla == this.Regla &&
                    ((Reglamento)obj).Copias == this.Copias)
                {
                    return 0;
                }
                return -1;
            }
            return -1;
        }
    }
}
