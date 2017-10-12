using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Estructuras
{
    public class ListaDoblementeEnlazada<T> where T : IComparable
    {
        /// <summary>
        /// Nodos que almacenan la lista de datos
        /// </summary>
        public NodoLista<T> Nodos { get; private set; }

        /// <summary>
        /// Cantidad de datos almacenados en la lista
        /// </summary>
        public int Cantidad { get; private set; }

        /// <summary>
        /// Almacena el nombre de la lista, ese nombre será usado como nombre de archivo.
        /// </summary>
        private string NombreLista { get; set; }

        /// <summary>
        /// Constructor de la clase ListaDoblementeEnlazada
        /// </summary>
        /// <param name="nombreLista">
        /// Nombre con el que se almacenará la lista en memoria
        /// </param>
        public ListaDoblementeEnlazada(string nombreLista, bool crear)
        {
            NombreLista = nombreLista;
            Nodos = null;
            Cantidad = -1;
        }

        /// <summary>
        /// Agrega un elemento nuevo a la lista de datos.
        /// </summary>
        /// <param name="dato">
        /// El dato que desea agregar a la lista
        /// </param>
        public void Agregar(T dato)
        {
            if (Cantidad == -1)
            {
                Cantidad++;
                Nodos = new NodoLista<T>(dato, Cantidad);
            }
            else
            {
                AgregarRecursivo(dato, Nodos);
            }
        }

        /// <summary>
        /// Agrega a la lista de forma recursiva
        /// </summary>
        /// <param name="dato">Dato que se agregará a la lista</param>
        /// <param name="Nodo">El nodo que se está analizando para saber donde agregar</param>
        private void AgregarRecursivo(T dato, NodoLista<T> Nodo)
        {
            if (Nodo.Siguiente == null)
            {
                Cantidad++;
                Nodo.Siguiente = new NodoLista<T>(dato, Cantidad);
                Nodo.Siguiente.Anterior = Nodo;
            }
            else
            {
                AgregarRecursivo(dato, Nodo.Siguiente);
            }
        }

        /// <summary>
        /// Busca un nodo en la lista
        /// </summary>
        /// <param name="Dato">
        /// El dato que se quiere buscar en la lista
        /// </param>
        /// <returns>
        /// Retorna el nodo que contiene el dato correspondiente en el parámetro
        /// </returns>
        private NodoLista<T> BuscarNodo(T Dato)
        {
            if (Nodos == null)
            {
                throw new Exception("La lista está vacía");
            }
            else
            {
                return BuscarNodoRecursivo(Dato, Nodos);
            }
        }

        /// <summary>
        /// Busca el nodo con el dato indicado de forma recursiva
        /// </summary>
        /// <param name="Dato">Dato que se quiere buscar</param>
        /// <param name="Nodo">Nodo en el que se busca el dato</param>
        /// <returns>Retorna el nodo en el que se almacena el dato</returns>
        private NodoLista<T> BuscarNodoRecursivo(T Dato, NodoLista<T> Nodo)
        {
            if (Nodo == null)
            {
                throw new Exception("El dato no se encuentra en la lista");
            }
            else
            {
                if (Nodos.Dato.CompareTo(Dato) == 0)
                {
                    return Nodos;
                }
                else
                {
                    return BuscarNodoRecursivo(Dato, Nodos.Siguiente);
                }
            }
        }

        /// <summary>
        /// Busca en la posición indicada de la lista
        /// </summary>
        /// <param name="posicion">Posición en la que desea buscar</param>
        /// <returns>Devuelve el dato que está en esa posición</returns>
        public T Buscar(int posicion)
        {
            if (posicion > Cantidad)
            {
                throw new IndexOutOfRangeException("La posición que busca no se encuentra en la lista.");
            }
            NodoLista<T> nodo = BusarRecursivo(posicion, 0, Nodos);
            if (nodo == null)
            {
                throw new Exception("El elemento no existe en la lista");
            }
            return nodo.Dato;
        }

        public NodoLista<T> BusarRecursivo(int posicion, int actual, NodoLista<T> nodo)
        {
            if (actual == posicion)
            {
                return nodo;
            }
            else if (actual > Cantidad)
            {
                return null;
            }
            else
            {
                actual = actual + 1;
                return BusarRecursivo(posicion, actual, nodo.Siguiente);
            }
        }

        /// <summary>
        /// Busca en la posición indicada de la lista
        /// </summary>
        /// <param name="posicion">Posición en la que desea buscar</param>
        /// <returns>Devuelve el dato que está en esa posición</returns>
        private NodoLista<T> BuscarNodo(int posicion)
        {
            if (posicion > Cantidad)
            {
                throw new IndexOutOfRangeException("La posición que busca no se encuentra en la lista.");
            }
            NodoLista<T> retorno = Nodos;
            for (int i = 1; i < posicion; i++)
            {
                retorno = Nodos.Siguiente;
            }
            return retorno;
        }

        /// <summary>
        /// Elimina un nodo de la lista
        /// </summary>
        /// <param name="posicion">Posición en la que se encuentra el dato a eliminar</param>
        public void Eliminar(int posicion)
        {
            NodoLista<T> eliminar = BuscarNodo(posicion);
            eliminar.Anterior.Siguiente = eliminar.Siguiente;
            eliminar.Anterior.Siguiente.Anterior = eliminar.Anterior;
        }

        /// <summary>
        /// Actualiza el dato almacenado en un nodo de la lista
        /// </summary>
        /// <param name="posicion">Posición del dato en la lista</param>
        /// <param name="Dato">El dato nuevo</param>
        public void Actualizar(int posicion, T Dato)
        {
            NodoLista<T> actualizar = BuscarNodo(posicion);
            actualizar.Dato = Dato;
        }

        /// <summary>
        /// Actualiza el archivo de la lista.
        /// </summary>
        public void Guardar()
        {
            StreamWriter escritor = new StreamWriter("c:\\sysley\\" + NombreLista + ".list");
            if (Nodos != null)
            {
                NodoLista<T> temp = Nodos;
                for (int i = 0; i <= Cantidad; i++)
                {
                    temp.guardarNodo(escritor);
                    temp = temp.Siguiente;
                }
            }
            escritor.Close();
            escritor = null;
        }
    }
}
