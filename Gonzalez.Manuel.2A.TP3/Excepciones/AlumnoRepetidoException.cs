using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepción que se lanzará si un alumno ya se encuentra en una Universidad.
        /// </summary>
        public AlumnoRepetidoException() :base("Alumno repetido.")
        {

        }
    }
}
