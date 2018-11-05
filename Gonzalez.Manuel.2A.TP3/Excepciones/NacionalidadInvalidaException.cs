using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepción que se lanzará si una nacionalidad es erronea (Numero de DNI no corresponde a nacionalidad).
        /// </summary>
        public NacionalidadInvalidaException() :base("La nacionalidad no se condice con el número de DNI")
        {
        }

        /// <summary>
        /// Excepción que se lanzará si una nacionalidad es erronea (Numero de DNI no corresponde a nacionalidad).
        /// </summary>
        /// <param name="message">Mensaje personalizado.</param>
        public NacionalidadInvalidaException(string message) :base(message)
        {
        }
    }
}
