using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Julia.Clases
{
    public class Prestamo
    {
        public Grupo GrupoPrestado { get; set; }

        public int Copias { get; set; }

        public Usuarios Encargado { get; set; }

        public Prestamo(Grupo grupo, int copias, Usuarios encargado)
        {
            GrupoPrestado = grupo;
            Copias = copias;
            Encargado = encargado;
        }
    }
}
