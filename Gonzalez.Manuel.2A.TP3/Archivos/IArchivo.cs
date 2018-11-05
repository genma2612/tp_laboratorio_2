using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region Métodos
        /// <summary>
        /// Guarda el texto en un archivo.
        /// </summary>
        /// <param name="archivo">Ruta donde se guardará el archivo.</param>
        /// <param name="datos">Información a guardar.</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer.</param>
        /// <param name="datos">Variable donde se almacenará el texto.</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
        #endregion
    }
}
