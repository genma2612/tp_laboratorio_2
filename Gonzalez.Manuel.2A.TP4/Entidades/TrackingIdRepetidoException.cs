using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// Excepción por numero de tracking repetido.
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        public TrackingIdRepetidoException(string mensaje) :base(mensaje)
        {
        }

        /// <summary>
        /// Excepción por numero de tracking repetido.
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        /// <param name="inner">Inner Exception</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) :base(mensaje, inner)
        {
        }
        #endregion
    }
}
