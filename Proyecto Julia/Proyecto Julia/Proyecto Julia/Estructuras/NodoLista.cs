using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Estructuras
{
    public class NodoLista<T> where T : IComparable
    {
        /// <summary>
        /// Nodo anterior
        /// </summary>
        public NodoLista<T> Anterior { get; set; }
        /// <summary>
        /// Nodo siguiente
        /// </summary>
        public NodoLista<T> Siguiente { get; set; }

        public int ID { get; set; }
        /// <summary>
        /// Dato almacenado en el nodo
        /// </summary>
        public T Dato { get; set; }

        /// <summary>
        /// Constructor de la clase NodoLista
        /// </summary>
        /// <param name="dato">El dato que se almacenará en el nodo</param>
        public NodoLista(T dato, int id)
        {
            ID = id;
            Dato = dato;
            Anterior = null;
            Siguiente = null;
        }

        /// <summary>
        /// Guarda todos los datos del nodo en un archivo
        /// </summary>
        /// <param name="escritor">Objeto StreamWriter que escribirá en el archivo.</param>
        public void guardarNodo(StreamWriter escritor)
        {
            int anterior = -1, siguiente = -1;
            if (Anterior != null)
            {
                anterior = Anterior.ID;
            }
            if (Siguiente != null)
            {
                siguiente = Siguiente.ID;
            }
            string Cadena = ID.ToString() + "|" + anterior.ToString() + "|" + siguiente.ToString() + "|" + Dato.ToString();
            escritor.WriteLine(Cadena);
        }
    }
}
