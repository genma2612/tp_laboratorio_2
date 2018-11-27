using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades

        /// <summary>
        /// Lista de paquetes de Correo.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto, inicializa las lista de Threads y Paquetes.
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Finaliza todos los Threads.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                    item.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos de Correo.
        /// </summary>
        /// <param name="elementos">Correo</param>
        /// <returns>Cadena con información de los paquetes en Correo</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> l = (List<Paquete>)((Correo)elementos).Paquetes;
            StringBuilder retorno = new StringBuilder();
            foreach (Paquete item in l)
            {
                retorno.AppendFormat(item.ToString() + " ({0})\n", item.Estado);
            }
            return retorno.ToString();
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Ingresa un paquete al correo, siempre y cuando el Tracking ID no sea repetido.
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns>Correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                    throw new TrackingIdRepetidoException("Tracking ID repetido.");
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
        #endregion
    }
}
