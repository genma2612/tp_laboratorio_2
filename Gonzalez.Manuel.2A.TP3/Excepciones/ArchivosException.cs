using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepción que se lanzará si hubo un error al generar o leer un archivo.
        /// </summary>
        /// <param name="innerException">Excepción de origen.</param>
        public ArchivosException(Exception innerException) :base("Hubo un error con el archivo.", innerException)
        {
        }
    }
}
