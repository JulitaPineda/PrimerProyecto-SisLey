using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Estructuras
{
    public class Cola<T> where T : IComparable
    {
        /// <summary>
        /// Nodos que conforman la cola
        /// </summary>
        public NodoLista<T> Nodos { get; private set; }

        /// <summary>
        /// Nombre de la cola, es el nombre usado en el archivo
        /// </summary>
        private string NombreCola { get; set; }

        /// <summary>
        /// Cantidad de elementos que contiene la cola
        /// </summary>
        private int Cantidad { get; set; }

        /// <summary>
        /// Constructor de la clase Cola
        /// </summary>
        /// <param name="nombreCola">Nombre con el que se almacernará la cola en memoria</param>
        public Cola(string nombreCola)
        {
            Cantidad = -1;
            NombreCola = nombreCola;
        }

        /// <summary>
        /// Agrega un elemento a la cola
        /// </summary>
        /// <param name="dato">Elemento que se quiere agregar a al cola</param>
        public void Encolar(T dato)
        {
            if (Nodos == null)
            {
                Cantidad++;
                Nodos = new NodoLista<T>(dato, Cantidad);
            }
            else
            {
                EncolarRecursivo(dato, Nodos);
            }
        }

        /// <summary>
        /// Agrega de forma recursiva un elemento al final de la cola
        /// </summary>
        /// <param name="dato">Dato que se quiere encolar.</param>
        /// <param name="nodo">Nodo que se analiza.</param>
        public void EncolarRecursivo(T dato, NodoLista<T> nodo)
        {
            if (nodo.Siguiente == null)
            {
                Cantidad++;
                nodo.Siguiente = new NodoLista<T>(dato, Cantidad);
            }
            else
            {
                EncolarRecursivo(dato, nodo.Siguiente);
            }
        }

        /// <summary>
        /// Desencola de la cola y elimina el dato.
        /// </summary>
        /// <returns>Devuelve el dato que se desencoló.</returns>
        public T Desencolar()
        {
            T dato = Nodos.Dato;
            Nodos = Nodos.Siguiente;
            Nodos.Anterior = null;
            return dato;
        }

        /// <summary>
        /// Guarda actualiza el archivo de la cola.
        /// </summary>
        public void Guardar()
        {
            StreamWriter escritor = new StreamWriter(NombreCola + ".cola");
            NodoLista<T> nodo = Nodos;
            for (int i = 0; i <= Cantidad; i++)
            {
                nodo.guardarNodo(escritor);
                nodo = nodo.Siguiente;
            }
            escritor.Close();
        }
    }
}
