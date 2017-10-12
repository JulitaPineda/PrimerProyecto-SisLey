using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Clases
{
    public class Leyes : IComparable
    {
        /// <summary>
        /// Nombre de la ley
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Cantidad de copias que existen de la ley
        /// </summary>
        public int Copias { get; private set; }

        /// <summary>
        /// Contador de copias prestadas
        /// </summary>
        public int Prestamos { get; set; }

        /// <summary>
        /// Reglamentos asignados a esta ley
        /// </summary>
        public Estructuras.ListaDoblementeEnlazada<Reglamento> Reglamentos { get; set; }

        /// <summary>
        /// Constructor de la clase Leyes
        /// </summary>
        /// <param name="copias">Cantidad de copias que existen de la ley</param>
        /// <param name="regla">Regla inicial de la ley</param>
        public Leyes(string nombre, int copias, Reglamento regla)
        {
            if (copias > 5)
                throw new Exception("No se pueden crear más de 5 copias de la ley.");
            Copias = copias;
            Nombre = nombre;
            Reglamentos = new Estructuras.ListaDoblementeEnlazada<Reglamento>("Leyes", false);
            Reglamentos.Agregar(regla);
            Prestamos = 0;
        }

        /// <summary>
        /// Constructor de la clase leyes (usado en actualizar)
        /// </summary>
        /// <param name="nombre">Nombre de la ley</param>
        /// <param name="copias">Cantidad de copias que existen de la ley</param>
        /// <param name="reglas">Todos los reglamentos que tiene la ley</param>
        public Leyes(string nombre, int copias, Estructuras.ListaDoblementeEnlazada<Reglamento> reglas)
        {
            if (copias > 5)
                throw new Exception("No se pueden crear más de 5 copias de la ley.");
            Copias = copias;
            Nombre = nombre;
            Reglamentos = reglas;
        }

        /// <summary>
        /// Agrega una cantidad de copias a la ley
        /// </summary>
        /// <param name="cantidad">Cantidad de copias a agregar</param>
        public void agregarCopia(int cantidad)
        {
            if (cantidad + Copias > 5)
                throw new Exception("No se pueden crear más de 5 copias de la ley.");
            Copias += cantidad;
        }

        /// <summary>
        /// Elimina una cantidad de copias de la ley
        /// </summary>
        /// <param name="cantidad">Cantidad de copias a eliminar</param>
        public void eliminarCopia(int cantidad)
        {
            if (Copias - cantidad < 1)
                throw new Exception("No se pueden eliminar más de " + (4 - Copias) + " copias");
            Copias -= cantidad;
        }

        /// <summary>
        /// Devuelve un string para almacenar el objeto en un archivo
        /// </summary>
        /// <returns>String con el objeto</returns>
        public override string ToString()
        {
            string retorno = Nombre + "|" + Copias + "|";
            for (int i = 0; i < Reglamentos.Cantidad; i++)
            {
                if (i == Reglamentos.Cantidad - 1)
                    retorno += Reglamentos.Buscar(i).ToString();
                else
                    retorno += Reglamentos.Buscar(i).ToString() + "|";
            }
            return retorno;
        }

        /// <summary>
        /// Genera un string de todos los reglamentos relacionados con esta ley
        /// </summary>
        /// <returns>String con los reglamentos separados por coma</returns>
        public string devolverReglamentos()
        {
            string retorno = "";
            for (int i = 0; i <= Reglamentos.Cantidad; i++)
            {
                if (i == Reglamentos.Cantidad + 1)
                    retorno += Reglamentos.Buscar(i).Nombre;
                else
                    retorno += Reglamentos.Buscar(i).Nombre + ",";
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
            if (obj is Leyes)
            {
                if (((Leyes) obj).Nombre == this.Nombre && (((Leyes) obj).Copias == this.Copias))
                {
                    for (int i = 0; i < Reglamentos.Cantidad; i++)
                    {
                        if (((Leyes)obj).Reglamentos.Buscar(i).CompareTo(this.Reglamentos.Buscar(i)) != 0)
                        {
                            return -1;
                        }
                    }
                    return 0;
                }
                return -1;
            }
            return -1;
        }
    }
}
