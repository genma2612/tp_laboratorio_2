using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string _mensajeBase;

        /// <summary>
        /// Excepción que se lanzará si un DNI es erroneo (Rango no aceptado o caracteres no permitidos).
        /// </summary>
        public DniInvalidoException() :this("DNI inválido\n")
        {
        }

        /// <summary>
        /// Excepción que se lanzará si un DNI es erroneo (Rango no aceptado o caracteres no permitidos).
        /// </summary>
        /// <param name="e">Excepcion de origen.</param>
        public DniInvalidoException(Exception e) :this("DNI inválido\n", e)
        {        
        }

        /// <summary>
        /// Excepción que se lanzará si un DNI es erroneo (Rango no aceptado o caracteres no permitidos).
        /// </summary>
        /// <param name="message">Mensaje personalizado.</param>
        public DniInvalidoException(string message) :base(message)
        {
            this._mensajeBase = message;
        }

        /// <summary>
        /// Excepción que se lanzará si un DNI es erroneo (Rango no aceptado o caracteres no permitidos).
        /// </summary>
        /// <param name="message">Mensaje personalizado.</param>
        /// <param name="e">Excepcion de origen.</param>
        public DniInvalidoException(string message, Exception e) :base(message, e)
        {
        }
    }
}
