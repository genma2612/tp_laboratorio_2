using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepción que se lanzará si no hay un profesor disponible para una clase.
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {

        }
    }
}
