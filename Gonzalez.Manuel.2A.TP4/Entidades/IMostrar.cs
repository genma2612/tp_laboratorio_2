using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        #region Métodos

        /// <summary>
        /// Muestra los datos del elemento.
        /// </summary>
        /// <param name="elemento">Elemento</param>
        /// <returns>Cadena con la informacion de elemento.</returns>
        string MostrarDatos(IMostrar<T> elemento);
        #endregion
    }
}
