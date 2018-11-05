using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Métodos
        /// <summary>
        /// Guarda una cadena en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta donde se guardará el archivo.</param>
        /// <param name="datos">Cadena que contiene la información a guardar.</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                StreamWriter sw;
                using (sw = new StreamWriter(archivo, false))
                {
                    sw.Write(datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer.</param>
        /// <param name="datos">Cadena donde se almacenará el texto.</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = "";
            try
            {
                StreamReader sr;
                using (sr = new StreamReader(archivo, false))
                {
                    datos = sr.ReadToEnd();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
        #endregion
    }
}
