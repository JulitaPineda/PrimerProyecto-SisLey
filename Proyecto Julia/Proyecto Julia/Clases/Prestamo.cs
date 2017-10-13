using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Clases
{
    public class Prestamo : IComparable
    {
        public Leyes Ley { get; set; }
        /// <summary>
        /// Grupo al que se le hizo el prestamo
        /// </summary>
        public Grupo GrupoPrestado { get; set; }

        /// <summary>
        /// Cantidad de copias que se prestó
        /// </summary>
        public int Copias { get; set; }

        /// <summary>
        /// Usuario encargado del prestamo
        /// </summary>
        public Usuarios Encargado { get; set; }

        /// <summary>
        /// Constructor de la clase Prestamo
        /// </summary>
        /// <param name="grupo">Grupo al que se realiza el prestamo</param>
        /// <param name="copias">Copias que se prestan</param>
        /// <param name="encargado">Usuario encargado del prestamo</param>
        /// <param name="ley">Ley que se está prestando</param>
        public Prestamo(Grupo grupo, int copias, Usuarios encargado, Leyes ley)
        {
            Ley = ley;
            GrupoPrestado = grupo;
            Copias = copias;
            Encargado = encargado;
        }

        public override string ToString()
        {
            return Copias + "|" + GrupoPrestado.ToString() + "|" + Encargado.ToString() + Ley.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj is Prestamo)
            {
                if (((Prestamo) obj).Ley.CompareTo(this.Ley) == 0 && ((Prestamo)obj).Encargado.CompareTo(this.Encargado) == 0
                    && ((Prestamo)obj).GrupoPrestado.CompareTo(this.GrupoPrestado) == 0 && ((Prestamo)obj).Copias == this.Copias)
                {
                    return 0;
                }
                return -1;
            }
            return -1;
        }
    }
}
