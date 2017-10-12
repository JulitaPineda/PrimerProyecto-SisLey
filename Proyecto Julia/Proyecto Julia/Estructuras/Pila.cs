using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Estructuras
{
    public class Pila<T> where T : IComparable
    {
        /// <summary>
        /// Nodos que conforman la pila
        /// </summary>
        public NodoLista<T> Nodos { get; private set; }

        /// <summary>
        /// Nombre de la pila, es el nombre usado en el archivo
        /// </summary>
        private string NombrePila { get; set; }

        /// <summary>
        /// Cantidad de elementos que contiene la pila
        /// </summary>
        private int Cantidad { get; set; }

        /// <summary>
        /// Constructor de la clase Pila
        /// </summary>
        /// <param name="nombrePila">Nombre con el que se almacernará la cola en memoria</param>
        public Pila(string nombrePila)
        {
            Cantidad = -1;
            NombrePila = nombrePila;
        }

        /// <summary>
        /// Agrega un elemento a la pila
        /// </summary>
        /// <param name="dato">Elemento que se quiere agregar a al pila</param>
        public void Apilar(T dato)
        {
            if (Nodos == null)
            {
                Cantidad++;
                Nodos = new NodoLista<T>(dato, Cantidad);
            }
            else
            {
                ApilarRecursivo(dato, Nodos);
            }
        }

        /// <summary>
        /// Agrega de forma recursiva un elemento al final de la pila
        /// </summary>
        /// <param name="dato">Dato que se quiere apilar.</param>
        /// <param name="nodo">Nodo que se analiza.</param>
        public void ApilarRecursivo(T dato, NodoLista<T> nodo)
        {
            if (nodo.Siguiente == null)
            {
                Cantidad++;
                nodo.Siguiente = new NodoLista<T>(dato, Cantidad);
            }
            else
            {
                ApilarRecursivo(dato, nodo.Siguiente);
            }
        }

        /// <summary>
        /// Desapila de la pila y elimina el dato.
        /// </summary>
        /// <returns>Devuelve el dato que se desapiló.</returns>
        public T Desapilar()
        {
            return DesapilarRecursivo(Nodos);
        }

        /// <summary>
        /// Desapila de forma recursiva de la pila (quita el ultimo)
        /// </summary>
        /// <param name="nodo">El nodo que se está analizando</param>
        /// <returns>Devuelve el valor que contiene el último nodo</returns>
        public T DesapilarRecursivo(NodoLista<T> nodo)
        {
            if (nodo.Siguiente == null)
            {
                nodo.Anterior.Siguiente = null;
                nodo.Anterior = null;
                return nodo.Dato;
            }
            else
            {
                return DesapilarRecursivo(nodo.Siguiente);
            }
        }

        /// <summary>
        /// Guarda actualiza el archivo de la pila.
        /// </summary>
        public void Guardar()
        {
            StreamWriter escritor = new StreamWriter(NombrePila + ".pila");
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
