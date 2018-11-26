using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region Métodos

        /// <summary>
        /// Guarda en un archivo de texto la información de los paquetes.
        /// </summary>
        /// <param name="texto">Cadena a guardar.</param>
        /// <param name="archivo">Ruta.</param>
        /// <returns>Verdadero si se pudo guardar, falso si no se pudo.</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            bool retorno = false;
            try
            {
                StreamWriter sw;
                using (sw = new StreamWriter(archivo, true))
                {
                    sw.Write(texto);
                    retorno = true;
                }
            }
            catch (Exception c)
            {
                throw c;
            }
            return retorno;
        }
        #endregion
    }
}
